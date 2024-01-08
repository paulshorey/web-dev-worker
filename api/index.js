import { Router, createCors } from 'itty-router';

import index from './index';
import echo from './echo';
// import test from './test';
// import set from './set';
// import get_cron from './get/cron';

const { preflight } = createCors();

function endpoints(router) {
	const endpoints = [];

	/*
	 * Sentiment
	 */
	endpoints.push({
		method: 'all',
		path: '/echo/*',
		response: echo,
	});

	/*
	 * Documentation
	 */
	endpoints.push({
		method: 'get',
		path: '/',
		response: index.bind({ status: 200 }),
	});
	endpoints.push({
		method: 'get',
		path: '*',
		response: index.bind({ status: 404 }),
	});

	/*
	 * Add each endpoint to router
	 */
	for (let endpoint of endpoints) {
		const { path, method, auth = [], response } = endpoint;
		router[method](path, (request, env, ctx) => {
			return response(request, env, ctx);
		});
	}
}

const router = Router();
router.all('*', preflight);
endpoints(router);

export default {
	async fetch(request, env, context) {
		for (const [key, value] of Object.entries(env)) {
			process.env[key] = value;
		}
		return await router.handle(request, env, context);
	},
	// async scheduled(event, env, ctx) {
	// 	ctx.waitUntil(get_cron(event, env, ctx));
	// },
};
