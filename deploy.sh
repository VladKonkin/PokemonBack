#! /bin/bash 

rm -rf ./docker-compose.override.yml

docker compose down

echo "Building and starting Docker containers..."
docker compose up --build -d

echo "Removing old unused images..."
docker image prune -f

echo "Deployment complete!"
