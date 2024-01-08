import { parse_error_message } from './err';

export default async function JsonResponse(objectOrPromise: Record<any, any> | Promise<Record<any, any>>, status = 200, pretty = true) {
	const data =
		objectOrPromise instanceof Promise ? await objectOrPromise : status !== 200 ? parse_error_message(objectOrPromise) : objectOrPromise;
	return new Response(JSON.stringify(data, null, pretty ? 2 : 0), {
		status: status,
		headers: {
			'content-type': 'application/json;charset=UTF-8',
			'Access-Control-Allow-Origin': '*',
			'Access-Control-Allow-Methods': 'GET,HEAD,POST,OPTIONS',
			'Access-Control-Max-Age': '86400',
		},
	});
}
