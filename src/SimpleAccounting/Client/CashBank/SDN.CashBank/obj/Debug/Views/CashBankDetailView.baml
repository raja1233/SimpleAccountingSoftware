   M S B A M L   `   `   `  ����G  CSDN.CashBank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SDN.CashBank.ViewsSDN.CashBank.Views  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      +    %SDN.CashBank.Views.CashBankDetailView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:SDN.CashBank.Views     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      6sys&clr-namespace:System;assembly=mscorlib     5      -   5        $
��auto��5
      $
��auto��6-     � 	Resources  5      0  *SDN.Common.Converter.SelectedItemConvertor   SelectedItemToItemsSource  CashBankGrid � ColumnDefinitions � RowDefinitions �� DisplayMemberPath �� SelectedIndex �� RelativeSource �� AncestorType �� BindingGroupName �� UpdateSourceTrigger	 d� 	IsChecked
 �� 
IsReadOnly �� Orientation  ButtonStyle��%H  &	        &	        5   
   6(   �� 5   
   .R�5      � $��	10 0 10 0q�6    5      �� 5      6)   �� 5      6)   �� 5      6)    5      �� 5      $	��90* �6$   63   �� 5      $	��10* �6$   63   .+�55      � $��0��6   $��0��6$   $��2��64    56      �� 57      6-   �� 58      $��2* �6+   68    5:      �� 5;      $
��auto �6(   68   �� 5<      $
��auto �6(   68   �� 5=      $
��auto �6(   68   �� 5>      $
��auto �6(   68   �� 5?      $
��auto �6(   68   �� 5@      $
��auto �6(   68   �� 5A      $
��auto �6(   68   �� 5B      $	��15* �6(   67   �� 5C      6*   .+�5E      �� $��0��6    $��0��6-   6?   �� 5F      $��1��6    $��0��6-   $��Account Name��6=   $
��Left=�6Q   6n   �� 5G      $��
cmbAccInfo��6t   -   5        $
��Left=�5G      $��1��6:   $��1��6J   $	��300��6W   $��7 2 2 0q�6c   $ AccountName��5I   N    5G   �   �� *SeletedIndex+��5H      �� *-+DataContext.SelectedCashBank.AccountDetails+ �� *FindAncestor+" >�5I   p   �� 5J      $��2��6    $��0��6-   6?   �� 5K      $��3��6   $��0��6,   $��Inactive��5L      {�5K   <   �� *	IsEnabled+$ Group1��$ PropertyChanged=�	 5L   1   �� *
IsInActive+$ Group1��$ PropertyChanged=�6�   �� 5M      $��4��6    $��0��6-   $��Account Type��6=   6S   �� 5N      $��4��6   $��1��6+   $	��300��6;   $��7 2 2 0q�6J   
 . $
��Left=�6n   $	��300��5O   y   ��6   �� *AccountType+$ Group1��$ PropertyChanged=�.��6�   5Q      �� 5R      $��4��6    $��1��6-   $	��300��6=   $��	310 2 2 0q�6L   $��Center=�6_   $��Cannot be changed��6z   6�   �� 5S      $��5��6    $��0��6-   $��Account Name��6=   6S   ]� 5T      $��5��6    $��1��6-   .+�5U      �� $��0,0,0,6q�6%   $��*��66   
���  ��5V      �� 5W      $��5��6"   $��1��6/   $	��300��6?   $��2 2 2 2q�6N   $
��Left=�6�   $	��300��6�   ��6_   �� *AccountName+$ Group1��$ PropertyChanged=�6�   5X      �� 5Y      $��6��6    $��0��6-   $��Opening Balance��6=   6V   �� 5Z      $��6��6   $��1��6+   $	��300��6;   $��7 2 2 2q�6J   $
��Left=�6�   $	��300��6�   ��6[   �� *AccountOpeningBal+$ Group1��$ PropertyChanged=�6�   �� 5[      $��7��6    $��0��6-   $��2��6=   $z��tif you want to create an account for a bank loan do not create a Bank Account. Create a long term liability account.��6Q   $��Italic$�6�   6�   �� 5\      $��8��6    $��0��6-   6?   5]      � 5y      $��1��6   $	��800��6$   $
��1000��64   $��Bottom=�6E   $��2��6`   $��0   0   0   10q�6p    5z      �� 5{      6*    5}      �� 5~      6-   �� 5      $��3* �6+   68   .+�5�      �� $ 
Horizontal=�6!   $��0��6:   $��3��6K   $��Right=�6_   $��
10,-5,0,10q�6|   .+�5�      �� $��Delete��6!   $
��10 0q�63   #���  6A   ��6g   �� * DataContext.ClickDeleteCommand+ �� " ���� 5�      $	��New��6!   $
��10 0q�60   #���  6>   ��6d   �� *DataContext.ClickNewCommand+ �� " ���� 5�      $
��Save��6"   $
��10 0q�62   #���  6@   ��5�   "   �� *DataContext.ClickSaveCommand+ �� " ���� 5�      $��Cancel��6!   $
��10 0q�63   #���  6A   5�      5�      5�      5�      5�      .��5�   
   �� #��[ 6P   $	��Top=�6�   $��5,5,5,5q�6�    � BindingGroup 6   �� *UpdateBindingGroup+ �� Mode$ TwoWay=���6}   �� *SelectedCashBank+ �� 	Converter# [  6�   5�      