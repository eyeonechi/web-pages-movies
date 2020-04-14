@CODE
    ' Working with numbers
    Dim a = 4
    Dim b = 5
    Dim theSum = a + b

    ' Working with characters (strings)
    Dim technology = "ASP.NET"
    Dim product = "Web Pages"

    ' Working with objects
    Dim rightNow = DateTime.Now
End Code

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8" />
        <title>Testing Razor Syntax</title>
        <style>
            body {
                font-family: Verdana;
                margin-left: 50px;
                margin-top: 50px;
            }
            div {
                border: 1px solid black;
                width: 50%;
                margin: 1.2em;
                padding: 1em;
            }
            span.bright {
                color: red;
            }
        </style>
    </head>
    <body>
        <h1>Testing Razor Syntax</h1>
        <form method="post">
            <div>
                <p>The value of <em>a</em> is @a. The value of <em>b</em> is @b.</p>
                <p>The sum of <em>a</em> and <em>b</em> is <strong>@theSum</strong>.</p>
                <p>The product of <em>a</em> and <em>b</em> is <strong>@(a * b)</strong>.</p>
            </div>
            <div>
                <p>The technology is @technology, and the prduct is @product.</p>
                <p>Together they are <span class="bright">@(technology + " " + product)</span></p>
            </div>
            <div>
                <p>The current date and time is: @rightNow</p>
                <p>The URL of the current page is <br /><br /><code>@Request.Url</code></p>
            </div>
        </form>
    </body>
</html>
