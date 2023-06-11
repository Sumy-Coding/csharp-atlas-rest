# csharp-atlas-rest

Checking C# for interacting with Atlassian Confluence/Jira via HTTP/TCP.

```bash
curl -d '{"fields": {"project": {"key": "AAA"}, "summary": "curl test", "issuetype": {"id": 10006}, "description": "test" } }' \
     -X POST --user admin:admin \ 
     -H "Content-Type: application/json" \
     http://localhost:9500/rest/api/2/issue
```

```bash
http POST :9500/rest/api/2/project/AAA --json \
     fields[project][key]='AAA' \
     fields[issuetype][id]:=10006 \
     fields[summary]='pie test' \
     fields[description]='pie test'
     
     
```