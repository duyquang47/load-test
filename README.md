# loadbalancer-simpleapp-csharp

A simple app to drain servers' resources, switching from Node.JS to C# for better resource usage.

Original work: [SimpleApp (Node.JS)](https://github.com/jerapiblaze/loadbalancer-appication)

Docker Hub: [SimpleApp (C#)](https://hub.docker.com/r/jerapiblannett/loadbalancersimpleappcsharp)

## API list

App listens on port `8080` (fixed).

| Method | Endpoint | Parameters | Resource bond | Description |
|:-------|:---------|:-----------|:--------------|:------------|
| GET    | `/` | None | None | Return string `Hello world`.|
| GET    | `/api/Pi/{n}` | $n\in(1,\infty)$ | CPU | Calculate $\pi$ with `n` rounds. |
| GET    | `/api/Recurse/{n}` | $n\in(1,24)$ | MEM | Calculate `n` recursives. |
