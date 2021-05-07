# ImageProcessor

The main solution consists of 3 projects:
- Blazor.ImageApi: acts as the backend/API, used to retrieve images then send selection data for processing
- Blazor.ImageClient: acts as the frontend, allowing the user to load an image then submit an area selection/view analysis results
- Blazor.ImageSharedLibrary: contains classes/interfaces shared between the API and frontend

(Blazor.ImageServer was for experimenting and is unused)

The main ImageViewer.razor page requests an image from the API (currently hardcoded to 'malaria.png' as an example). The image is then loaded onto the page with an svg element overlaid onto it to allow the user to drag a selection box.

When a selection has been made, the 'submit selection' button is clickable, at which point the selection data (image name, coordinates and width/height) are sent to the API. The API then passes this data to an IImageProcessor, which loads the specified area of the image before passing it on to an IImageAnalyser for processing.

Currently, the ImageAnalyser simply returns three results consisting of random coordinates and test messages. These are then returned to the client, where they are overlaid onto the selection area as red dots that can be hovered over to view the messages.

If the user wishes to make a new selection, they must click the 'clear selection' button to clear the existing selection area/results. This is to prevent users accidentally clicking on the box and clearing their existing selection.
