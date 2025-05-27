Jag har valt att köra på den ordinarie VG featuren och skapat en favoritmeny. I favoritmenyn ingår en "Triple Cheesy Ham & Turkey Deluxe" Sub, en cola, chips och en äppelpaj.

Jag har gjort så att när man klickar på "Specials" i sidenaven så routas man till /specials och favorit menyn visas upp. Om man klickar på favoritmenyn läggs hela den menyn i varukorgen.
Ett problem jag inte har hunnit fixa är när man routar tillbaka till /order från /specials genom att klicka på ett annat alternativ i sidenaven så behöver man klicka 2 gånger för att få upp produkterna.

Jag har gjort så eftersom att i instruktionerna står det att man behöver en ny vy (FavoriteMenyView.vue) för att visa upp menyn. Hade det inte behövts hade jag visat favoritmenyerna i MainPage.vue som vi gör med produkterna utan att behöva routa till /specials.