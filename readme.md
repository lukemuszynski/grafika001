Pojęcia:

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

(Jeśli wybrany obiekt znajduje się w grupie obiektów to akcja wykonywana jest na tej grupie)
  * DeleteObjectButton - usuwa wybrany obiekt
  * MoveObjectButton - przesuwa wybrany obiekt (przesunięcie obliczane jest od punktu na który kliknęliśmy przy wybieraniu obiektu)

* Suwak promienia okręgu

* AddVerticle - dodaje wierzchołek w dokładnym punkcie kliknięcia

* MoveVerticle - przesuwa wybrany wierzchołek

* SetHorizont - ustawia krawędź na poziomą (jeśli akcja nie może być wykonana nic się nie stanie)

* SetVertical - ustawia krawędź na pionową (jeśli akcja nie może być wykonana nic się nie stanie)

* ConcentricCircles - po kliknięciu mamy możliwość wyboru okręgów które chcemy połączyć w grupę okręgów
