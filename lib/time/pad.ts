export default function pad(num: number | string) {
	if (typeof num === 'number') {
		if (num < 10) {
			return '0' + num;
		}
	}
	if (typeof num === 'string') {
		if (num.length < 2) {
			return '0' + num;
		}
	}
	return num.toString();
}
