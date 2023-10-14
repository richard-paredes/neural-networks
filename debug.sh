# TODO: Learn how to run these processes in the background and terminate once this script is exited
npx tailwindcss -i ./src/StoryMaster/Styles/app.css -o ./src/StoryMaster/wwwroot/css/app.css --watch
dotnet watch --project ./src/StoryMaster

