   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SDN.CashBank.ViewsSDN.CashBank.Views  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      ,    &SDN.CashBank.Views.AccountsDetailsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:SDN.CashBank.Views     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      6sys&clr-namespace:System;assembly=mscorlib     5      -   5        $
��auto��5
      $
��auto��6-     � 	Resources  5      0  *SDN.Common.Converter.SelectedItemConvertor   SelectedItemToItemsSource  AccountGrid � ColumnDefinitions � RowDefinitions �� Path �� UpdateSourceTrigger �� SelectedValuePath �� DisplayMemberPath �� SelectedIndex �� Mode	 �� RelativeSource
 �� AncestorType �� SelectedValue ��Name �� Triggers �� Value �� Binding �� 
TargetName �� Property �� Value �� 
TargetType �Name �� Triggers P� Property P� Value ��Name  ButtonStyle �� BindingGroupName d� 	IsChecked  DisabledTextBox �� 
IsReadOnly �� 	IsEnabled �� Command �� 	MaxLength �� Orientation��%!  &	        &	      7    5   
   6(   �� 5   
   .R�5      � $��10 0 5 0q�6    5      �� 5      6*   �� 5      6*   �� 5      6*   �� 5      6)    5      �� 5      $	��300 �6$   63   �� 5      $
��Auto �6$   64   .+�59      � $��0��6   $��0��6$   $��5��64   $	��300��6H    5:      �� 5;      $	��300 �6+   69   �� 5<      $��2* �6+   68   �� 5=      6-   �� 5>      6-    5@      �� 5A      $
��auto �6(   68   �� 5B      $
��auto �6(   68   �� 5C      $
��auto �6(   68   �� 5D      $
��auto �6(   68   �� 5E      $
��auto �6(   68   �� 5F      $
��auto �6(   68   �� 5G      $
��auto �6(   68   �� 5H      $
��auto �6(   68   �� 5I      $	��13* �6(   67   �� 5J      6*   .+�5L      �� $��0��6    $��0��6-   6?   �� 5M      $��1��6    $��0��6-   $��Account Name��6=   $
��Left=�6Q   6n   ]� 5N      $��1��6    $��1��60   .+�5O      �� $��MyLabel��6    
�������$	��8pt(�6B   $��Right=�6Q   $��
-30,0,10,0q�6t   $	��Top=�6�   $��23��6�   ��5P      �� $ 
HashSymbol�$ PropertyChanged=��� 5R      $��
cmbAccInfo��6x   -   5        $
��Left=�5R   #   $��1��6>   $��1��6N   $	��250��6[   $��7 2 2 0q�6g   
���   �$ AccountName��5T   J   $ AccountName��6�    5R   �   �� *SeletedIndex+��5S   +   �� *,*DataContext.SelectedAccount.AccountDetails+$ TwoWay=�$ PropertyChanged=�	 �� *FindAncestor+"
 >� 5T   j   �� *MySelectedItem+��5U      �� 5V   "   .R�5W   &   �� $ AccountName��60   ��6E   �� *AccountName+6d    5X   &   �� 5Y   *   $
 True��5[   /    5Z   /   �� $ DataContext.IsLinked�	 �� *TemplatedParent+.a�5\   .   �� $ AccountName��6K    � ��
 �����5]   /   5^   +   5`   #   ��5b      �� 5c   "   " ��6(   .�5d   &   ��  � �� 5e   *   �� 5f   .   .R�5g   2   � $ gd��67   
���   � 5h   6   �� 5i   :   $	��190 �6K   �� 5j   :   $	��125 �6K   .+�5l   6   �� $��5q�6@   $��0��6K   ��6[   �� *AccountName+�� 5m   6   $��15 0 0 0q�6@   $��1��6R   ��6c   �� *AccountTypeName+5n   3    5o   2   P� 5p   6    �@��
IsSelected . . �5q   :   �� $ gd��6A    � ��
 �   �6x   �� 5r   :   $ gd��6A    � ��
 �����6�   5s   7   P� 5t   6    �@J�IsMouseOver . . �5u   :   �� $ gd��6A    � ��
 �����6w   �� 5v   :   $ gd��6A    � ��
 �����6�   5w   7   5y   /   5{   '   5|   #   5~      �� 5�      $ GoNext��6!   $	�� < ��61   $
��Left=�6�   $��Center=�6�   $��30��6�   $	��5 0q�6�   #���  6�   {�6B   �� *EnablePrevious+$ Group1��$ PropertyChanged=���6  �� *DataContext.PreviousCommand+	 �� *FindAncestor+"
 >��� 5�      $ GoBack��6!   $	�� > ��61   $��2��6�   $
��Left=�6�   $��Center=�6�   $��30��6�   $
��10 0q�6�   #���  6  {�6B   �� *
EnableNext+$ Group1��$ PropertyChanged=���6+  �� *DataContext.NextCommand+	 �� *FindAncestor+"
 >�5�      ]� 5�      $��2��6    $��1��60   $
��10,0q�6=   .+�5�      �� $��Active (��6%   $��10,0,0,0q�65   6I   �� 5�      $��2,1,2,1q�6�   ��6%   �� *DataContext.ActiveAccounts+	 �� "
 >�6�   �� 5�      $��)��6%   60   �� 5�      $��
Inactive (��6%   $��10,0,0,0q�67   6K   �� 5�      $��2,1,2,1q�6�   ��6%   �� *DataContext.InActiveAccounts+	 �� "
 >�6�   �� 5�      $��)��6%   60   5�      �� 5�      $��3��6!   $��0��6.   $��	0 15 2 15q�6>   .+�5�      �� 
���   �$��Inactive��5�   0   {�5�   $   �� *	IsEnabled+$ Group1��$ PropertyChanged=� 5�   D   �� *
IsInActive+$ Group1��$ PropertyChanged=�6�   5�      �� 5�      $��4��6    $��0��6-   $��Account Type��6=   $��0 2 2 4q�6R   6e   �� 5�      $��cmbAccInfotype��6   -   5        $
��Left=�5�   �   $��4��6�   $��1��6�   $	��250��6�   $��7 2 2 4q�6�   $ AccuntTypeCode��6  
���   �$ AccountName��5�      {�5�   h   �� *AccoutTypeCombo+ 6�   �� *SeletedAccountType+��5�   ,   �� *DataContext.GetAccountTypes+	 �� *FindAncestor+"
 >�5�   ?   �� 5�      $��5��6    $��0��6-   $��Account Name��6=   $��0 2 2 4q�6R   6e   ]� 5�      $��5��6    $��1��6-   .+�5�      �� $��0,0,0,6q�6%   $��*��66   
���  ��5�      �� 5�      $��txtAccountName��6K   8��  
���   �$��5��6�   $��1��6�   $	��250��6�   $��2 2 2 4q�6�   $
��Left=�68  $	��300��6S   6u   �� *ReadOnlyAccountName+��6�   �� *AccountName+$ Group1��$ PropertyChanged=�.��6b  5�      5�      ]� 5�      $��7��6    $��1��6-   $��	100,0,0,0q�6=   .+�5�      �� $��xLink��6$   $y�Hidden=�61   �� 5�   "    .   60   �� *DataContext.ActiveInactive+	 �� "
 >�.�6�   Go To Account6�   5�      5�      �� 5�      $��6��6    $��0��6-   $��Opening Balance��6=   6V   �� 5�      -   5        $
��left=�5�   J   
���   �$��6��6�   $��1��6�   $	��250��6�   $��7 2 2 4q�6�   $
��Left=�6J  $	��300��6e  $ 18��6t   6   �� *EnableOpeningBalance+��6�   �� *AccountOpeningBal+$ Group1��$ PropertyChanged=�6�  �� 5�      $��0 20 0 0q�6    $��7��62   $��0��6?   $��2��6O   $C��=#Linked accounts cannot be made inactive, renamed or deleted.��6c   $��Italic$�6�   
�������6�   �� 5�      $��9��6    $��0��6-   6?   �� 5�      $��8��6   $��0��6*   $	��300��6:   $��0 0 0 0q�6G   #���  6X   $	��New��6�   ��6~   �� *!DataContext.EnterClosingBalance+	 �� "
 ��.��6  31Enter Previous Accounting System Closing Balances6?  �� 5�      $��8��6   $��1��6*   $	��150��6;   $	��New��6�   $��Start New Financial Year��6�   $��
-150 0 0 0q�6�   #���  6  ��6G   �� *#!DataContext.StartFinancialCommand+	 �� "
 ��6  5�      � 5�      $��1��6   $��Right=�6$   $��Bottom=�6@   $��2��6[   $��2��6k   ��6   �� *AccountGridHeight+ 5�      �� 5�      6*    5�      �� 5�      6-   �� 5�      $��3* �6+   68   .+�5�      �� $��Bottom=�6!   $ Vertical=�6<   $��0��6S   $��3��6d   $��Right=�6x   $��10,-15,0,20q�6�   .+�5�      �� 
���  ��$
��Wrap=�69   ��6M   �� *Errors+$ TwoWay=�$ PropertyChanged=�6�   �� 5�      $��Bottom=�6%   $ 
Horizontal=�6@   $��Right=�6Y   .+�5�      �� $��Bottom=�6%   $��Delete��6d   $
��10 0q�6v   #���  6�   {�6@   �� *DeleteEnabled+��6�   �� * DataContext.ClickDeleteCommand+	 �� "
 ���� 5�      $��Bottom=�6%   $	��New��6@   $
��10 0q�6O   #���  6]   ��6�   �� *DataContext.ClickNewCommand+	 �� "
 ���� 5�      $��Bottom=�6%   $
��Save��6A   $
��10 0q�6Q   #���  6_   ��5�   "   �� *DataContext.ClickSaveCommand+	 �� "
 ���� 5�      $��Bottom=�6%   $��Close��6@   $��10 0 0 0q�6�   #���  6�   ��6R   �� *DataContext.CloseCommand+	 �� "
 ��6�   5�      5�      5�      5�      5�      5�      .��5�      �� -   5        $��ContentsItemControl��5�      #��[ 6g   $	��Top=�6�   $��5,5,5,5q�6	    � BindingGroup  6.   �� *UpdateBindingGroup+$ TwoWay=���6�   �� *SelectedAccount+! �� 	Converter#! [  6	  5�      