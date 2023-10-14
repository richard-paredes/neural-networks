# TODO: Learn how to run these processes in the background and terminate once this script is exited
npx tailwindcss -i ./Styles/app.css -o ./wwwroot/css/app.css --watch
dotnet watch --project src/StoryMaster

