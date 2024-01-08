import pad from './pad';

export default function iso(timestamp: number): {
	year: string;
	month: string;
	day: string;
	hour: string;
	minute: string;
	second: string;
	string: string;
} {
	const date = new Date(timestamp);
	const year = pad(date.getFullYear());
	const month = pad(date.getMonth() + 1);
	const day = pad(date.getDate());
	const hour = pad(date.getHours());
	const minute = pad(date.getMinutes());
	const second = '00';
	const string = `${year}-${month}-${day}T${hour}:${minute}:${second}Z`;
	return { year, month, day, hour, minute, second, string };
}
