Projekt 2:

* StartDrawPolygon - budowanie wielokątu. Kolejne wierzchołki ustawiane przez kliknięcie na polu do rysowania.

* StopDrawPolygon - końcy budowanie wielokątu, łączy pierwszy wierzchołek z ostatni.

* Light Color Picker - wybor koloru swiatla poprzez klikniecie na ponizszym boxie, wybrany kolor wypelnia mniejszy box po prawej stronie

* Text box pod color pickerem ustawia odległość punktu światła w płaszczyźnie Z, Int32.TryParse()

* Polygon Color Picker - wybor koloru nastepnego utworzonego przez nas wielokatu, dzialanie analogiczne z powyższym Light Color Picker

* Start Animation Button - generuje losowy wielokąt o losowym kolorze i przesuwa go z prawej do lewej strony ekranu

* Stop Animation Button - zatrzymuje animację i usuwa wygenerowany na potrzeby animacji wielokąt

* Select Polygon Button - zaznacza wielokąt leżący najbliżej kliknięcia

* Delete Polygon Button - usuwa zaznaczony wielokąt

* Set Light Position Button - po kliknięciu możemy wybrać na głównej bitmapie pozycję światła

Projekt 1: Pojęcia:

1. Grupa obiektów: 
	a) ConcentricCircles - logicznie połączone ze sobą okręgi
	b) Poligon - połączone ze sobą linie tworzące wielokąt


* SetPixel - ustawia pixel na mapie, funkcja testowa

* DrawLine - rysuje pojedynczą linię, pozycja linii ustalana przez 2 kliknięcia na polu do rysowania.

* StartDrawPolygon - budowanie wielokątu. Kolejne wierzchołki ustawiane przez kliknięcie na polu do rysowania.

* StopDrawPolygon - końcy budowanie wielokątu, łączy pierwszy wierzchołek z ostatni.

* Ustawienia wielkości rysowanych obiektów:
	smallWidth - 1px
	mediumWidth - 3px
	bigWidth -5px

* Select element - wybiera obiekt do przekształcenia (wierzchołek, linia, wielokąt, okrąg, zespół okręgów). Punkt na którym będą wykonywane inne akcje po wyborze jest dokładnym punktem kliknięcia.

* DrawCircle - rysuje okrąg o promieniu ustalonym za pomocą pierwszego od góry suwaka.

* ClearBitmap - czyści pole do rysowania ze wszystkich obiektów.

* TextBox - czas który zajęło wykonanie akcji w sekundach

* (Jeśli wybrany obiekt znajduje się w grupie obiektów to akcja wykonywana jest na tej grupie)
  * DeleteObjectButton - usuwa wybrany obiekt
  * MoveObjectButton - przesuwa wybrany obiekt (przesunięcie obliczane jest od punktu na który kliknęliśmy przy wybieraniu obiektu)

* Suwak promienia okręgu

* AddVerticle - dodaje wierzchołek w dokładnym punkcie kliknięcia

* MoveVerticle - przesuwa wybrany wierzchołek

* SetHorizont - ustawia krawędź na poziomą (jeśli akcja nie może być wykonana nic się nie stanie)

* SetVertical - ustawia krawędź na pionową (jeśli akcja nie może być wykonana nic się nie stanie)

* ConcentricCircles - po kliknięciu mamy możliwość wyboru okręgów które chcemy połączyć w grupę okręgów
