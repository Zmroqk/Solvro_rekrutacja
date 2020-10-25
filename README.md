# Solvro_rekrutacja
<h3>Dokumentacja dla tego projektu znajduje się pod tym linkiem: https://zmroqk.github.io/Solvro_rekrutacja/</h3>
<h3>Link do obrazu docker: https://hub.docker.com/r/zmroqk/solvrocity_rekrutacja</h3>
<b>
Nigdy wcześniej nie używałem dockera więc nie jestem pewien czy będzie on działał.
Do uruchomienia aplikacji wymagane jest kilka zmiennych środowiskowych, które mam nadzieje są w obrazie.
Jeśli natomiast tam ich nie ma to można je znaleść tutaj: https://github.com/Zmroqk/Solvro_rekrutacja/blob/master/Solvro_city/Properties/launchSettings.json</br>
Oczywiście zmienne te są danymi wrażliwymi więc nie powinny się one znajdować w kodzie na githubie, jednakże nie jest to prawdziwy projekt więc tak to zostawię.
</b>

<b>Kilka uwag do projektu:</b></br>
Rejestracja i logowanie użytkowników wykorzystuje bazę sqlite.
Baza jest generowana przez bibliotekę Entity Framework, więc w celu uproszczenia przesłałem ją na githuba, jednakże w normalnej sytuacji przesłał bym ją za pomocą protokołu ftp
na serwer docelowy, a najlepiej wogle bym niestosował tego rozwiązania na serwerze www. Plik bazy jest zabezpieczony hasłem (hasło w zmiennych środowiskowych).

Z treści zadania nie wynikało czy ścieżki <b>/stops</b> i <b>/path?source=...&target=...</b> mają być dostępne po zalogowaniu. Moie api napisałem więc tak, że wymaga ono logowania do tych ścieżek.
Sposób autoryzacji: Token JWT.
