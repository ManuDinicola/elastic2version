#run elastic7

```
docker run -p 127.0.0.1:9200:9200 -p 127.0.0.1:9300:9300 -e "discovery.type=single-node"  -e "http.cors.enabled=true"  -e "http.cors.allow-origin=/.*/"  --name es7 docker.elastic.co/elasticsearch/elasticsearch:7.17.18
```

#run elastic8

```
docker network create elastic
docker run --name es8 --net elastic -p 9200:9200 -it -m 1GB -e "http.cors.enabled=true"  -e "http.cors.allow-origin=/.*/" docker.elastic.co/elasticsearch/elasticsearch:8.12.2
```

Use elasticvue for creating index and populate data

```
docker run -p 8080:8080 --name elasticvue -d cars10/elasticvue
```

