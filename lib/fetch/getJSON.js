export default async function getJSON(url) {
	return await fetch(url).then((response) => response.json());
}
