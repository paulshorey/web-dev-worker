export default async function parseData(request) {
	let postData = null;
	// if content-type is JSON, parse it:
	if (request.headers.get('content-type') === 'application/json') {
		postData = await request.json();
	} else {
		postData = await request.text();
	}
	return postData;
}

// also path and query string:
// const url = new URL(request.url);
// const queryString = Object.fromEntries(url.searchParams.entries());
