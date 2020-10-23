# Solvro_rekrutacja
Solvro city backend rekrutacja

<h4>Dokumentacja dla tego projektu znajduje się pod tym linkiem: https://zmroqk.github.io/Solvro_rekrutacja/</h4>

<b>Kilka uwag do projektu:</b></br>
Rejestracja i logowanie użytkowników wykorzystuje bazę sqlite, której wcześniej nie stosowałem.
Baza jest generowana przez bibliotekę Entity Framework, więc w celu uproszczenia przesłałem ją na githuba, jednakże w normalnej sytuacji przesłał bym ją za pomocą protokołu ftp
na serwer docelowy. Plik bazy jest zabezpieczony hasłem.
Plik appsettings.json został przeze mnie ukryty gdyż zawiera on zmienne środowiskowe z hasłami, więc na githubie znajduje się appsetings.example.json z 
wytycznymi jak uzupełnić plik. Przygotowywuję jednak obraz Dockera (a przynajmniej mam nadzieję, że mi się uda bo nigdy go niestosowałem), więc wszystkie potrzebne 
hasła będą znajdować się w zmiennych środowiskowych.

Z treści zadania nie wynikało czy ścieżki <b>/stops</b> i <b>/path?source=...&target=...</b> mają być dostępne po zalogowaniu, więc w moim api zrobiłem, że wymagają one logowania.
Sposób autoryzacji: Token JWT.
