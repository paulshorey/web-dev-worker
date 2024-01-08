import JsonResponse from '@/lib/response/JSON';

export default async function (request) {
	// all headers
	const headers = {};
	for (const [key, value] of request.headers) {
		headers[key] = value;
	}
	// all cookies
	const cookieHeader = request.headers.get('Cookie') || '';
	const cookies = Object.fromEntries(
		cookieHeader.split('; ').map((cookie) => {
			const [name, value] = cookie.split('=');
			return [name, decodeURIComponent(value)];
		})
	);
	// query string
	const url = new URL(request.url);
	const queryString = Object.fromEntries(url.searchParams.entries());
	// path segments
	const pathSegments = url.pathname.split('/').filter(Boolean);
	// post data
	let jsonData = {};
	const contentType = request.headers.get('Content-Type') || '';
	let data: any;
	if (contentType.includes('application/json')) {
		data = await request.json();
	} else if (contentType.includes('application/x-www-form-urlencoded') || contentType.includes('multipart/form-data')) {
		data = await request.formData();
		data = Object.fromEntries(data);
	} else {
		data = await request.text();
	}

	// response
	return JsonResponse({
		method: request.method,
		contentType: contentType,
		path: pathSegments,
		query: queryString,
		data: data,
		headers,
		cookies,
	});
}
