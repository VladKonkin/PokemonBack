#! /bin/bash 

rm -rf ./docker-compose.override.yml

echo "Building and starting Docker containers..."
docker compose up --build -d

echo "Removing old unused images..."
docker image prune -f

echo "Deployment complete!"
