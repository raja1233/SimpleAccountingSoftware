   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SDN.CashBank.ViewsSDN.CashBank.Views  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      +    %SDN.CashBank.Views.CashBankDetailView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:SDN.CashBank.Views     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      6sys&clr-namespace:System;assembly=mscorlib     5      -   5        $
��auto��5
      $
��auto��6-     � 	Resources  5      0  *SDN.Common.Converter.SelectedItemConvertor   SelectedItemToItemsSource  CashBankGrid � ColumnDefinitions � RowDefinitions �� DisplayMemberPath �� SelectedIndex �� RelativeSource �� AncestorType �� BindingGroupName �� UpdateSourceTrigger	 d� 	IsChecked
 �� 
IsReadOnly �� 	MaxLength �� Orientation  ButtonStyle��%F  &	        &	        5   
   6(   �� 5   
   .R�5      � $��10 0 5 0q�6    5      �� 5      6)   �� 5      6)   �� 5      6)    5      �� 5      $	��90* �6$   63   �� 5      $	��10* �6$   63   .+�56      � $��0��6   $��0��6$   $��2��64    57      �� 58      6-   �� 59      $��2* �6+   68    5;      �� 5<      $
��auto �6(   68   �� 5=      $
��auto �6(   68   �� 5>      $
��auto �6(   68   �� 5?      $
��auto �6(   68   �� 5@      $
��auto �6(   68   �� 5A      $
��auto �6(   68   �� 5B      $
��auto �6(   68   �� 5C      $
��auto �6(   68   �� 5D      $	��13* �6(   67   �� 5E      6*   .+�5G      �� $��0��6    $��0��6-   6?   �� 5H      $��1��6    $��0��6-   $��Account Name��6=   $
��Left=�6Q   6n   �� 5I      $��
cmbAccInfo��6t   -   5        $
��Left=�5I      $��1��6:   $��1��6J   $	��300��6W   $��7 2 2 0q�6c   
���   �$ AccountName��5K   N    5I   �   �� *SeletedIndex+��5J   ,   �� *-+DataContext.SelectedCashBank.AccountDetails+ �� *FindAncestor+" >�5K   p   �� 5M      $��3��6!   $��0��6.   $��	0 15 2 15q�6>   .+�5O      �� 
���   �$��Inactive��5P   0   {�5O   $   �� *	IsEnabled+$ Group1��$ PropertyChanged=�	 5P   D   �� *
IsInActive+$ Group1��$ PropertyChanged=�6�   5R      �� 5T      $��4��6    $��0��6-   $��Account Type��6=   $��0 2 2 4q�6R   6e   �� 5U      $��4��6   $��1��6+   $	��300��6;   $��7 2 2 4q�6J   
 . $
��Left=�6n   
���   �$	��300��5V   �   ��61   �� *AccountType+$ Group1��$ PropertyChanged=�6�   �� 5W      $��4��6    $��1��6-   $	��300��6=   $��	310 2 2 4q�6L   $��Center=�6_   $��Cannot be changed��6z   6�   �� 5X      $��5��6    $��0��6-   $��Account Name��6=   $��0 2 2 4q�6R   6e   ]� 5Y      $��5��6    $��1��6-   .+�5Z      �� $��0,0,0,6q�6%   $��*��66   
���  ��5[      �� 5\      $��txtAccountName��6"   
���   �$��5��6�   $��1��6�   $	��300��6�   $��2 2 2 4q�6�   $
��Left=�69  $	��300��6T  {�6L   �� *ReadOnlyAccountName+
 6v   �� *ReadOnlyAccountName+��6�   �� *AccountName+$ Group1��$ PropertyChanged=�6e  5]      �� 5^      $��6��6    $��0��6-   $��Opening Balance��6=   6V   �� 5_      -   5        $��Right=�5_      
���   �$��6��6�   $��1��6�   $	��300��6�   $��7 2 2 4q�6�   $
��Left=�6  $	��300��6:  $ 18��6I  ��6�   �� *AccountOpeningBal+$ Group1��$ PropertyChanged=�6Z  �� 5`      $��0 20 0 0q�6    $��7��62   $��0��6?   $��2��6O   $>��8Cash account cannot be made inactive, rename or deleted.��6c   $��Italic$�6�   
�������6�   �� 5a      $��0 20 0 0q�6    $��8��62   $��0��6?   $��2��6O   $z��tif you want to create an account for a bank loan do not create a Bank Account. Create a long term liability account.��6c   $��Italic$�6�   
�������6  �� 5b      $��9��6    $��0��6-   6?   5c      � 5      $��1��6   $	��640��6$   $
��1000��64   $��Bottom=�6E   $��2��6`   $��0   0   0   100q�6p    5�      �� 5�      6*    5�      �� 5�      6-   �� 5�      $��3* �6+   68   .+�5�      �� $ 
Horizontal=�6!   $��0��6:   $��3��6K   $��Right=�6_   $��
10,-5,0,10q�6|   .+�5�      �� $��Delete��6E   $
��10 0q�6W   #���  6e   {�6!   �� *DeleteEnabled+��6�   �� * DataContext.ClickDeleteCommand+ �� " ���� 5�      $	��New��6!   $
��10 0q�60   #���  6>   ��6d   �� *DataContext.ClickNewCommand+ �� " ���� 5�      $
��Save��6"   $
��10 0q�62   #���  6@   ��5�   "   �� *DataContext.ClickSaveCommand+ �� " ���� 5�      $��Close��6!   $��10 0 0 0q�62   #���  6D   5�      5�      5�      5�      5�      .��5�      �� -   5        $��ContentsItemControl��5�      #��[ 6g   $	��Top=�6�   $��5,5,5,5q�6   � BindingGroup 6.   �� *UpdateBindingGroup+ �� Mode$ TwoWay=���6�   �� *SelectedCashBank+ �� 	Converter# [  6  5�      