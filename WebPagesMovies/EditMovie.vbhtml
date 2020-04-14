@Code
    Layout = "~/_Layout.vbhtml"
    Page.Title = "Edit a Movie"

    Dim title = ""
    Dim genre = ""
    Dim year = ""
    Dim movieId = ""

    If Not IsPost() Then
        If Not Request.QueryString("Id").IsEmpty() And Request.QueryString("Id").IsInt() Then
            movieId = Request.QueryString("Id")
            Dim db = Database.Open("WebPagesMovies")
            Dim dbCommand = "SELECT * FROM Movies WHERE Id = @0"
            Dim row = db.QuerySingle(dbCommand, movieId)

            If row IsNot Nothing Then
                title = row.Title
                genre = row.Genre
                year = row.Year
            Else
                Validation.AddFormError("No movie was found for that Id")
            End If
        Else
            Validation.AddFormError("No movie was selected.")
        End If
    End If

    If IsPost() Then
        Validation.RequireField("title", "You must enter a title")
        Validation.RequireField("genre", "Genre is required")
        Validation.RequireField("year", "You haven't entered a year")
        Validation.RequireField("movieId", "No movie ID was submitted!")

        title = Request.Form("title")
        genre = Request.Form("genre")
        year = Request.Form("year")
        movieId = Request.Form("movieId")

        If Validation.IsValid() Then
            Dim db = Database.Open("WebPagesMovies")
            Dim updateCommand = "UPDATE Movies SET Title=@0, Genre=@1, Year=@2 WHERE Id=@3"
            db.Execute(updateCommand, title, genre, year, movieId)
            Response.Redirect("~/Movies")
        End If
    End If

End Code

<h2>Edit a Movie</h2>
@Html.ValidationSummary()
<form method="post">
    <fieldset>
        <legend>Movie Information</legend>
        <p>
            <label for="title">Title:</label>
            <input type="text" name="title" value="@title" />
        </p>
        <p>
            <label for="genre">Genre:</label>
            <input type="text" name="genre" value="@genre" />
        </p>
        <p>
            <label for="year">Year:</label>
            <input type="text" name="year" value="@Year" />
        </p>
        <input type="hidden" name="movieId" value="@movieId" />
        <p>
            <input type="submit" name="buttonSubmit" value="Submit Changes" />
        </p>
    </fieldset>
</form>
<p>
    <a href="~/Movies">Return to movie listing</a>
</p>
