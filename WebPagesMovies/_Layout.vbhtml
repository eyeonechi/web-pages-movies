<!DOCTYPE html>
<html>
    <head>
        <title>@Page.Title</title>
        <link href="~/Styles/Movies.css" rel="stylesheet" type="text/css" />
    </head>
    <body>
        <div id="container">
            <div id="header">
                <h1>Web Pages Movies</h1>
            </div>
            <div id="main">
                @RenderBody()
            </div>
            <div id="footer">
                &copy; @DateTime.Now.Year Web Pages Movies
            </div>
        </div>
    </body>
</html>
