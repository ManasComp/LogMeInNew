docker compose up -d db
docker compose build
docker compose up -d logmein
curl http://0.0.0.0:8080/health
