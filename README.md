Семинарска работа по Визуелно програмирањe - Memory Game
============


Опис на проблемот:
============
Се работи за игра која им овозможува на лицата да си ги тестираат своите способности за меморирање. Целта на играта е да се погодат две исти квадратчиња т.е. при кликање на нив тие да имаат иста боја. За да биде играта успешно завршена треба да се погодат сите квадратчиња да бидат во иста боја.
<br/><br/>Опис на играта:http://en.wikipedia.org/wiki/Concentration_(game)


Интерфејс, функционалности и правила:
============
При стартување на апликацијата се појавуваат три менија. Менито File е поставено прво и ви овозможува два избори. Со избирање на New Game се стартува играта со 2 редици и 3 колони. Во второто мени Options можете да изберете Board Size за да се појават квадратчиња според ваш избор. При кликање на втората опција Exit од менито File апликацијата се затвара, додека при избирање на опциите од менито Help се наоѓаат About this Game(link до интернет страна за играта) и Instructions(помош како треба да играте).

<img src="http://s24.postimg.org/tp6knhmyt/image.png" >
<img src="http://s24.postimg.org/5mpqsm6bp/image.png" >
<img src="http://s24.postimg.org/6q9v4kqyt/image.png" >

Програмско решение:
============
Решението ги содржи следниве функции кои се дел од Form1:
- private Color colorFunc()
  - Funkcija koja se koristi za odbiranje na pozadinska boja za kvadratite. Funkcijata koristi generator na slucajni broevi za da opredeli indeks za bojata. Indeksot sluzi za pristap do poleto colorsList i zemanje na soodvetnata boja od tamu. Poleto colorsUsed gi sodrzi site boi za inicijalizacija. Nizata colorUsed sluzi za oznacuvanje koja od boite vo colorsList e zafatena. Sekoja od boite vo colorsList moze da se javi najmnogu dvapati na nacrtanite kvadrati.

- private void CreateTable()
 - Funkcija koja sluzi za iscrtuvanje na kvadratite. Sekoj kvadrat e objekt od klasata Button. Prvo se kreira matrica od kopcinja so odbranite dimenzii (x i y). Potoa poedinecno se kreira sekoe kopce, se postavuvaat negovite dimenzii, pocetna pozicija, ime i se dodava nastan za klikanje na istoto. Istovremeno, se od bojata koja ke bide povrzana so soodvetniot kvadrat (kopce), a potoa istiot se dodava na panel.

<img src="http://s24.postimg.org/c33awg491/image.png" >


Израболе:
============
Бојана Самарџиоска, Бр. индекс: 117021<br/>
Ангела Марковиќ, Бр. индекс: 117013<br/>
ИНФО
