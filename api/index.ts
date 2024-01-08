import JsonResponse from '@/lib/response/JSON';
// import * as process from "node:process"

export default async function () {
	const data = {
		'/': 'index',
		'/echo/*': {
			'/echo/anything1/anything2': 'returns the request paths, querystring, data, headers, and cookies',
		},
	};
	return JsonResponse(data, this.status);
}
