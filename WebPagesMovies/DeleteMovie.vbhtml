@Code
    Layout = "~/_Layout.vbhtml"
    Page.Title = "Delete a Movie"

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
                Validation.AddFormError("No movie was found for that ID.")
            End If
        Else
            Validation.AddFormError("No movie was found for that ID.")
        End If
    End If

    If IsPost() And Not Request("buttonDelete").IsEmpty() Then
        movieId = Request.Form("movieId")
        Dim db = Database.Open("WebPagesMovies")
        Dim deleteCommand = "DELETE FROM Movies WHERE Id = @0"
        db.Execute(deleteCommand, movieId)
        Response.Redirect("~/Movies")
    End If

End Code

<h2>Delete a Movie</h2>
@Html.ValidationSummary()
<p>
    <a href="~/Movies">Return to movie listing</a>
</p>
<form method="post">
    <fieldset>
        <legend>Movie Information</legend>
        <p>
            <span>Title:</span>
            <span>@title</span>
        </p>
        <p>
            <span>Genre:</span>
            <span>@genre</span>
        </p>
        <p>
            <span>Year:</span>
            <span>@Year</span>
        </p>
        <input type="hidden" name="movieId" value="@movieId" />
        <p>
            <input type="submit" name="buttonDelete" value="Delete Movie" />
        </p>
    </fieldset>
</form>
