select album.albumId, album.Title,genre.Name,artist.Name,album.price,album.url from album
left join artist
on [album].[ArtistId] = [Artist].[ArtistId]
left join genre
on album.GenreId = genre.GenreId