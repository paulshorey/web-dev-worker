/**
 * @returns timestamp (milliseconds) in UTC timezone
 */
export default function timestamp(minutes = 0): number {
	const date = new Date();
	return date.getTime() - date.getTimezoneOffset() * 60000 + minutes * 60000;
}
