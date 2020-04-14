@Code
    Layout = "~/_Layout.vbhtml"
    Page.Title = "List Movies"

    Dim db = Database.Open("WebPagesMovies")
    Dim selectCommand = "SELECT * FROM Movies"
    Dim searchTerm = ""

    If Not Request.QueryString("searchGenre").IsEmpty() Then
        selectCommand = "SELECT * FROM Movies WHERE Genre = @0"
        searchTerm = Request.QueryString("searchGenre")
    End If

    If Not Request.QueryString("searchTitle").IsEmpty() Then
        selectCommand = "SELECT * FROM Movies WHERE Title LIKE @0"
        searchTerm = "%" + Request("searchTitle") + "%"
    End If

    Dim selectedData = db.Query(selectCommand, searchTerm)
    Dim grid = New WebGrid(source:=selectedData, defaultSort:="Genre", rowsPerPage:=3)
End Code

<h2>Movie List</h2>
<form method="get">
    <div>
        <label for="searchGenre">Genre to look for:</label>
        <input type="text" name="searchGenre" value="@Request.QueryString("searchGenre")" />
        <input type="submit" value="Search Genre" /><br />
        (Leave blank to list all movies.)<br />
    </div>
    <div>
        <label for="searchTitle">Movie title contains the following:</label>
        <input type="text" name="searchTitle" value="@Request.QueryString("searchTitle")" />
        <input type="submit" value="Search Title" /><br/>
    </div>
</form>
<div>
    @grid.GetHtml(
                                tableStyle:="grid",
                                headerStyle:="head",
                                alternatingRowStyle:="alt",
                                columns:=grid.Columns(
                                    grid.Column("", format:=@@<a href="~/EditMovie?id=@item.Id">Edit</a>),
                                    grid.Column("Title"),
                                    grid.Column("Genre"),
                                    grid.Column("Year"),
                                    grid.Column("", format:=@@<a href="~/DeleteMovie?id=@item.Id">Delete</a>)
                                )
                            )
</div>
<p>
    <a href="~/AddMovie">Add a movie</a>
</p>
