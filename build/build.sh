# Prepare
file="TuanAnhHoang_CV.pdf"
if [ -f "$file" ] ; then
    rm "$file"
fi
killall ngrok

project="./build/HtmlToPdf/HtmlToPdf.csproj"
app="./build/app/HtmlToPdf"

# Getting stuff
echo "Intializing..."
sh -c "python -m http.server 8000" & echo "Running HTTP Server"
sh -c "./ngrok http 8000" & echo "Running Ngrok"
echo "Waiting for 5 seconds." && sleep 5
echo "\nUp and running!\n"
echo "Building HtmlToPdf..."
sh -c "dotnet build $project -c Release -o ./build/app/"
echo "Finish building! Getting PDF..."
sh -c "$app"

# Cleanup

echo "Clean up build..." & sh -c "rm -r ./build/app"
sh -c "ls ./build"
killall ngrok
echo "Killed ngrok."

