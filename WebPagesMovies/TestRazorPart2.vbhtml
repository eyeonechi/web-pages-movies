@CODE
    Dim message = "This is the first time you've requested the page."
    If IsPost Then
        message = "Now you've submitted the page."
    End If

    Dim showMessage = False
    If Request.QueryString("show").AsBool().Equals(True) Then
        showMessage = True
    End If
End Code

<!DOCTYPE html>
<html lang="en">
    <head>
        <title>Testing Razor Syntax - Part 2</title>
        <meta charset="utf-8" />
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
        </style>
    </head>
    <body>
        <h1>Testing Razor Syntax - Part 2</h1>
        <form method="post">
            <div>
                @If showMessage Then
                    @<p>@message</p>
                End If
                <p><input type = "submit" value="Submit" /></p>
                @If IsPost Then
                    @<p>You submitted the page at @DateTime.Now</p>
                End If
            </div>
        </form>
    </body>
</html>
