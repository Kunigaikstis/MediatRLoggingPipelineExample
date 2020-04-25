# MediatRLoggingPipelineExample
Showcases how you can use MediatR pipelines to perform extensive logging.

Code for the blog post: https://dev.to/raulismasiukas/logging-pipeline-with-mediatr-5d4f

In the blog post Ive outlined a few gotchas in regards to this approach:
1. If the request executes further requests, the `GUID` will change and you won't be able to trace the caller in a reassuring way. Each subsequent request will have a different `GUID`. 
2. All available data will be serialized using the `JsonSerializer`. This can be an issue, especially when dealing with private user data. The easiest way to overcome this is to annotate fields that you don't want to log with the `[JsonIgnore]` attribute but that comes with its own catch, for example: if you're using the `IRequest` object as the request body (`[FromBody]`) in a controller method then you're gonna miss out on the ignored values.
3. ALL available data will be serialized. Long text files may muddy your logs, you'll hear sirens in the distance.
