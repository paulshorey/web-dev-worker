# Getting started

To use KV on localhost, in development, run:

```
wrangler kv:namespace create 'per_minute' --preview
```

To use it in production, run:

```
wrangler kv:namespace create 'per_minute'
```

Add both to wrangler.toml file:

```
kv_namespaces = [
  { binding = "per_minute", id = "a1845272896d49cdb4a4a61cb88dfd50", preview_id = "c33a7c24efa0429090e557e37100478e" }
]
```
