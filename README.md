# AzureBugRepro
A standalone project to reproduce the issue of incorrect json being generated while logging using azure diagnostics. 

## Issue
Whenever an object that has a collection of objects and a few other null properties is logged in azure diagnostics, the logged json drops a bracket, making the log files contain invalid json.

## Reproduction
Build and deploy the project to Azure, then make a post to `/api/values` with the following input:
```
{
	"name" : "Some name",
	"valueCollection": ["7dfdc479-7b76-4a58-8c98-7d1afefa7256"],
	"objectCollection": [{
	    "name" : "Some other name",
	    "lastModified": "2016-10-18T20:53:45.488Z"
	}]
}
```

The json produced in the logs looks like this:
```
// the state object has a missing end brace
{
    'timestamp': '2016-10-20 20:17:16.001 +00:00',
    'level': 'Warning',
    'message': '{"eventId":1001,"eventName":"MyObjectCreated","message":"An object has been created","state":{"name":"Some name","valueCollection":["7dfdc479-7b76-4a58-8c98-7d1afefa7256"],"objectCollection":[{"name":"Some other name","lastModified":"2016-10-18T20:53:45.488Z"}],"lastModified":null,"propertyA":null,"propertyB":null,"propertyC":null,"option":null}',
    'exception': ''
}
```
