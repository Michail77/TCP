   M S B A M L   `   `   `  ����@  <Aukro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Aukro.ViewModelAukro.ViewModel  5   	   G(clr-namespace:Aukro.ViewModel.ConvertersAukro.ViewModel.Converters  5   	   clr-namespace:AukroAukro  5	   	       Aukro.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,vmclr-namespace:Aukro.ViewModel     5   	   9conv(clr-namespace:Aukro.ViewModel.Converters     5   	   X TXceed.Wpf.Toolkit, Version=3.7.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   localclr-namespace:Aukro  5	   	     � Title$  Aukro��5   	   $	��450��6   $	��800��6$    � 	Resources 5      3  -Aukro.ViewModel.Converters.IntToTimeConverter   IntToTimeConverter5  /Aukro.ViewModel.Converters.RadioButtonConverter  RadioButtonConverter��%:   &	        &	        5   
   6"     5   
   6$   5       � DataContext 5      #  Aukro.ViewModel.MainViewModel  5   
   .��5      � .+�5   
   �� .@�5      �� $��Aukce��6   .��5      � .+�5      	� $��Všechny aukce��6"   $��10,346,661,24q�6:    d� 	IsChecked 6Q   �� *	Selection+ �� 	Converter# [  �� ConverterParameter$ 1��	� 5      $��
Moje aukce��6"   $	��100��67   $��125,346,561,24q�6C    6[   �� *	Selection+# [ $ 2��	� 5      $��
Vyhrávám��6"   $	��100��65   $��225,346,461,24q�6A    6Y   �� *	Selection+# [ $ 3��	� 5      $��Vyhráno��6"   $	��100��64   $��325,346,361,24q�6@    6X   �� *	Selection+# [ $ 4���� 5      -   5         ��Name$ 	ListView1��5      $
��Left=�6S   $	��277��6n   $��	10,10,0,0q�6{   $	��Top=�6�   $	��766��6�   ��62   �� *
Auctions+ �� View 5      �� 5      .P�5   "   �� $��Název��61    �� Width$ 80��6@   	 �� DisplayMemberBinding	 6K   �� *Name+�� 5   "   $��Popis��61   $ 80��6@   	 6K   �� *Description+�� 5    "   $��Aktuální cena��61   $ 80��6H   	 6S   �� *CurrentPrice+�� 5!   "   $��Prodávající��61   $ 80��6F   	 6Q   �� *SellerUserId+�� 5"   "   $��Vyhrávající��61   $ 80��6F   	 6Q   �� *WinnerUserId+�� 5#   "   $��Kup teď��61   $ 80��6B   	 6M   �� *BuyNowPrice+�� 5$   "   $��Konec��61   $	 125��6@   	 6L   �� *	EndTime+# [  �� 5%   "   $��	Přihodit��61   $	 125��6C   
 �� CellTemplate
 5&   &   �� 5'   *   .R�5(   .   �� $��Přihoď��65   ��6F   ��  �� ElementName$ 	ListView1�� �� Path$ DataContext.AuctionBet���6�   �� *	AuctionId+5)   +   5+   #   5,      5.      �� 5/      $��	Příhoz:��6   $��435,340,297,11q�6.   �� 50      $
��Left=�6   $��23��69    �� TextWrapping$
 Wrap=�6E   $	��Top=�6Y   $	��120��6q   $��489,344,0,0q�6}   ��6�   �� *Money+51      52      �� 53      $��	Uživatel��6   y�6(   �� *
Visibility+ �� 
IsSelected 6K   �� *
IsLogged+ �� Mode$ OneWay=�.��54      � .+�55      �� $��Uživatelské jméno:��6   $��10,10,658,341q�69   �� 56      $��	Odhlásit��6   $
��Left=�60   $��	10,55,0,0q�6K   $	��Top=�6^   $��75��6v   ��6�   �� *Logout+{�6�   �� *
IsLogged+�� 57      $��Přidání aukce��6   $��10,80,686,276q�64   �� 58      $��Název:��6   $��10,115,686,241q�6-   �� 59      $��Popis:��6   $��10,150,686,206q�6-   �� 5:      $��Cena:��6   $��10,185,686,171q�6,   �� 5;      $��Cena kup teď:��6   $��10,220,686,136q�64   �� 5<      $��Konec:��6   $��10,255,686,101q�6-   �� 5=      $
��Left=�6   $��23��69   $
 Wrap=�6E   $	��Top=�6Y   $	��120��6q   $��105,115,0,0q�6}   ��6�   �� *AuctionName+�� 5>      $
��Left=�6   $��23��69   $
 Wrap=�6E   $	��Top=�6Y   $	��120��6q   $��105,154,0,0q�6}   ��6�   �� *AuctionDescription+�� 5?      $
��Left=�6   $��23��69   $
 Wrap=�6E   $	��Top=�6Y   $	��120��6q   $��105,189,0,0q�6}   ��6�   �� *AuctionPrice+�� 5@      $
��Left=�6   $��23��69   $
 Wrap=�6E   $	��Top=�6Y   $	��120��6q   $��105,224,0,0q�6}   ��6�   �� *AuctionBuyNowPrice+&   Xceed.Wpf.Toolkit.DateTimePicker  5A      $
��Left=�6*   $��23��6E   $	��Top=�6Q   $	��120��6i   $��105,259,0,0q�6u   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum 6�   �� *	MaxTime+   Minimum 6�   �� *	MinTime+   Value 6�   �� *AuctionEndTime+�� 5C      $��Přidej aukci��6   $
��Left=�64   $	��Top=�6O   $��75��6g   $��
10,290,0,0q�6r   ��6�   �� *
AddAuction+{�6�   �� *
IsLogged+�� 5D      $��145,10,511,341q�65   ��6   �� *Name+65   5E      5F      �� 5G      $��Login��6    6%   �� *
Selected+$ OneWay=�.��5H      � .+�5I      �� $��Jméno:��6   $��10,10,716,346q�6-   �� 5J      $��Heslo:��6   $��10,45,716,311q�6-   �� 5K      $��Přihlásit��67   $
��Left=�6K   $��	10,85,0,0q�6f   $	��Top=�6y   $��75��6�   ��6   �� *Login+6�   �� 5L      $
 Wrap=�6   $��70,10,581,351q�6}   ��62   �� *	LogName+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6}   �� 5M      $
 Wrap=�6   $��70,45,581,316q�6�   ��62   �� *LogPassword+$ TwoWay=�$ PropertyChanged=�6�   5N      5O      �� 5P      $��
Registrace��6   .��5Q      � .+�5R      �� $��Jméno:��6   $��10,10,721,346q�6-   �� 5S      $��Heslo:��6   $��10,45,721,311q�6-   �� 5T      $��Registrovat��6   $
��Left=�6P   $��	10,85,0,0q�6k   $	��Top=�6~   $��75��6�   ��63   �� *
Register+6�   �� 5U      $
 Wrap=�6   $��70,10,581,351q�6}   ��62   �� *	RegName+$ TwoWay=�$ PropertyChanged=�6}   �� 5V      $
 Wrap=�6   $��70,45,581,316q�6�   ��62   �� *RegPassword+$ TwoWay=�$ PropertyChanged=�6�   5W      5X      �� 5Y      $��Uživatelé��6   .��5Z      � .+�5[      �� $
��Left=�6=   $	��277��6X   $��	10,10,0,0q�6e   $	��Top=�6x   $	��766��6�   ��6   �� *Users+ 5\      �� 5]      .P�5^   "   �� $��Id��61   $ 80��6=   	 6H   �� *UserId+�� 5_   "   $��Uživatelské jméno��61   $	 120��6L   	 6X   �� *
Username+�� 5`   "   $��Heslo��61   $ 80��6@   	 6K   �� *
Password+5a      5c      5e      5f      5g      5h      5i      