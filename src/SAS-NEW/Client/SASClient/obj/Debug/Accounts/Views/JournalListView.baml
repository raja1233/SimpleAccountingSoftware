   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SASClient.Accounts.ViewsSASClient.Accounts.Views  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      ;,clr-namespace:SDN.Common;assembly=SDN.Common
SDN.Common 5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	      .    (SASClient.Accounts.Views.JournalListView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:SASClient.Accounts.Views     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      ;my,clr-namespace:SDN.Common;assembly=SDN.Common     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5	      $
��1024��5
      .��5      �� $��Stretch=�6   $
��Auto=�62   $
��Auto=�6U   .��5   
   �   � 	Resources  5      9  3SDN.Common.Converter.TextInputToVisibilityConverter "  TextInputToVisibilityConverter,  &SDN.Common.Converter.DateTimeConverter  DateTimeFormatter5  /SDN.Common.Converter.MultipleParameterConverter  MultiParamterConverter  BorderStyle �� 
TargetType �� Property �� Value  brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder��%H  &	        &	      &	 &     &	 9     &	 �     &	 �     &	 �       5      69     5      6H     5      6V   �� 5      " ��6,   .�5      ��  � ��$ 1q�68   �� 5       � ��
 �   �64   5      �� 5      $ White��6C   �� 5      $
 Gray��6C   �� 5      $ Black��6?   5       � RowDefinitions 5      �� 5      $��30 �6    6.   �� 5      $��80 �6    6.   �� 5       $��30 �6    6.   �� 5!      $
��Auto �6    60   �� 5"      $��40 �6    6.    � ColumnDefinitions 5%      �� 5&      $	��512 �6#   61   �� 5'      $	��256 �6#   61   �� 5(      $	��256 �6#   61   .+�5+      ��  �� Orientation$ 
Horizontal=�6   $��0��62   $��7,17,392,56q�6B   $��2��6W   .+�5,      	� -   5         	�Name$ radShowAllYes��5,      $��2 2 10 2q�6Y   	 	� 	GroupName$	 
radShowAll��6m   $��14��6�   $
��Left=�6�   ��65   �� *ShowAllCommand+
 d� 	IsChecked
 6�   �� *ShowAllTrue+ �� BindingGroupName$ Group1�� �� UpdateSourceTrigger$ PropertyChanged=�.��5-      ]� .+�5.      �� $��	Show All ��6%   68   5/      50      58      � 59      $��0��6   $��58��6#   $��2��62   $	��300��6C   $	��300��6R   $
��Left=�6a   $��116,14,0,34q�6}    5:      �� 5;      $	��12* �6'   65   �� 5<      $	��11* �6'   �� 5=      $	��92* �6'   65   �� 5>      $	��92* �6'   65   �� 5?      $	��93* �6'   65    5A      �� 5B      6&   �� 5C      6&   .+�5E      	� -   5        $ radyearmonthYes��5E   ;   $��0��6   $��0��6+   $	 radSelectionparameter��6T   $��2 0 5 0q�6v   $��2��5F   �   ��6   �� *YearQuarterSelectedCommand+
 6M   �� *YearmonthQuartTrue+$ Group1��$ PropertyChanged=�6�   �� 5G      $��0��6   $��2��6)   $��Center=�69   $��Center=�6V   $
��Year��6q   $��	34,4,34,3q�6}   6�   �� 5H      $��0��6   $��3��6)   $��Center=�69   $��Center=�6V   $��Quater��6q   $��	26,4,26,3q�6   6�   �� 5I      $��0��6   $��4��6)   $��Center=�69   $��Center=�6V   $��Month��6q   $��	27,4,27,3q�6~   6�   �� 5J      -   5        $��cmbYearSearch��5L   I   
���   �$��1��5J   /   $��2��6<    �� 
IsEditable .  �� DisplayMemberPath$
 Year��5L       �� SelectedValuePath$
 Year��60   $��0,0,0,-1q�5M   u   {�5J   L   �� *EnableYearDropDown+��5K      �� *	YearRange+ �� SelectedValue 5M      �� *SelectedSearchYear+ �� Mode$ TwoWay=�$ PropertyChanged=�6�   �� 5N      -   5        $��cmbQuarterSearch��5S   J   
���   �$��1��5N   /   $��3��6<    .  �� IsTextSearchEnabled .   �� IsTextSearchCaseSensitive .   �� StaysOpenOnEdit . $ Quarter��5S      $ ID��63   $��0,0,0,-1q�5T   x   {�5N   L   �� *EnableQuarterDropDown+ w� TextPath 5Q      �� *	Quarter+��5R      �� *QuarterList+ 5T      �� *SelectedSearchQuarter+$ TwoWay=�$ PropertyChanged=�6�   �� 5U      -   5        $��cmbMonthSearch��5W   H   
���   �$��1��5U   /   $��4��6<    . $ Month��5W      $ ID��61   $��0,0,0,-1q�5X   v   {�5U   L   �� *EnableMonthDropDown+��5V      �� *	MonthList+ 5X      �� *SelectedSearchMonth+$ TwoWay=�$ PropertyChanged=�6�   �� 5Y      $��2��6   $��0��6)   #��[ 66   6]   �� 5Z      $��2��6   $��1��6)   #��[ 66   6]   �� 5[      $��3��6   $��0��6)   #��[ 66   6]   �� 5\      $��3��6   $��1��6)   #��[ 66   6]   �� 5]      $��4��6   $��0��6)   #��[ 66   6]   �� 5^      $��4��6   $��1��6)   #��[ 66   6]   5`      � 5a      $��2��6   $��2��6'   $
��Left=�68   $��443,22,0,28q�6S   $	��300��6h   $	��600��6w   $	��275��6�    5b      �� 5c      6&   �� 5d      6&    5f      �� 5g      $
��.25* �6'   66   �� 5h      6)   �� 5i      6)   .+�5k      	� $��0��6   $��0��6+   $��
10 0  5 0 q�6;   $	 radSelectionparameter��6O   ��5l      �� *CalendarSelectionCommand+
 6J   �� *StartEndDateTrue+$ Group1��$ PropertyChanged=�6�   �� 5m      $��0��6   $��1��6)   $��
Start Date��69   6M   �� 5n      $��1��6   $��1��6)   $��End Date��69   6K   (  "System.Windows.Controls.DatePicker  5p      -   5        $
��Left=�5p   G   $	��150��6b   $	��150��6q   $��	-50 0 5 5q�6�   $��0��6�   $��2��5r      {�5p      �� *EnableStartDropDown+   SelectedDate 5r   -   �� *SelectedSearchStartDate+  5s      :  4System.Windows.Controls.Primitives.DatePickerTextBox ��Name �� 
IsReadOnly  BaseBorderBrush `� 	Converter �� Path �� RelativeSource �� AncestorType��%�  '        7  �� 5t      "  6    .�5u      ��  � �� 5v   "   �� 5w   &   .R�5x   *   �� $ PART_TextBox��63    . $��0q�6\   $��Stretch=�6p   $��Stretch=�6�   #���  6�   .��6�   ��5y   .   `� 5z   2   8   .1�5{   6   �� $ SelectedDate�6>   �� 5|   6   $ 
DateFormat�6>   6R   �� 5}   6   $) #DataContext.SelectedSearchStartDate�6>    5~   A   �� "  5�   3   .��5�   <   5�   +   5�   '   5�      5�      5�      5�        5�      -   5        $
��Left=�5�   E   $	��150��6`   $	��150��6o   $��	-50 0 5 5q�6~   $��1��5�   �   $��2��6�   {�5�      �� *EnableEndDropDown+   DisplayDateStart 5�   h   �� *EndDateValidation+ 6�   �� *SelectedSearchEndDate+  5�      ��%�  '        7  �� 5�      "  6    .�5�      ��  � �� 5�   "   �� 5�   &   .R�5�   *   �� $ PART_TextBox��62    . $��0q�6Z   $��Stretch=�6n   $��Stretch=�6�   #���  6�   .��6�   ��5�   .   `� 5�   2   8   .1�5�   6   �� $ SelectedDate�6>   �� 5�   6   $ 
DateFormat�6>   6R   �� 5�   6   $' !DataContext.SelectedSearchEndDate�6>    5�   A   �� "  5�   3   .��5�   <   5�   +   5�   '   5�      5�      5�      5�      5�      ]� 5�      $��0��6   $��4��6%   $��
-30 20 0 0q�65   $��2��6I   $��2��6]   .+�5�      �� $!��Select a Start and End date��6   
�������$��Italic$�6Q   6g   5�      �� 5�      -   5        $��cmbQuotNoSearch��5�   W   
������ #��[ 5�   0   $��0��6d   $��2��6t   $��	165 5 0 0q�6�    . $
��Left=�5�      $��3��62   $	��Top=�6@   $	��150��6X   $	��150��6g   $ JournalDate��5�      $ JournalDate��67   $	��146��5�   E   ��5�      �� *ComboDateList+ 5�      �� *SelectedJournalDate+6E   �� 5�      $��0��6   $
��Left=�6)   $	��Top=�6D   $��2��6\   $��20��6i     WaterMarkStyle#��[ 6v   $��	171,8,0,0q�6�   $��Search��6�   #��[ 6�   y�5�      `� 5�      # [  6#   .1�5�      ��  �� ElementName$ cmbQuotNoSearch��6"   $ Text.IsEmpty�6@   �� 5�      $ cmbQuotNoSearch��6"   $ 	IsFocused�6@   5�      5�      �� 5�      -	   5        $��cmbQuotNoSearch1��5�   O   
������ #��[ 5�   0   $��0��6d   $��2��6t   $��15 5 0 0q�6�    . $
��Left=�5�      $��3��62   $	��Top=�6@   $	��150��6X   $	��150��6g   $ JNumber��5�      $ JNumber��63   $	��146��5�   A   ��5�      �� *ComboJNumberList+ 5�      �� *SelectedJNumber+6A   �� 5�      $��0��6   $
��Left=�6)   $	��Top=�6D   $��2��6\   $��20��6i   #��[ 6v   $��18,5,0,0q�6�   $��Search��6�   #��[ 6�   y�5�      `� 5�      # [  6#   .1�5�      �� $ cmbQuotNoSearch1��6"   $ Text.IsEmpty�6A   �� 5�      $ cmbQuotNoSearch1��6"   $ 	IsFocused�6A   5�      5�      �� 5�      -
   5        $��cmbQuotNoSearch2��5�   U   
������ #��[ 5�   0   $��0��6d   $��2��6t   $��	315 5 0 0q�6�    . $
��Left=�5�      $��3��62   $	��Top=�6@   $	��150��6X   $	��150��6g   $ 
Amount1Str��5�      $ 
Amount1Str��66   $	��146��5�   @   ��5�      �� *ComboAmountList+ 5�      �� *SelectedAmount+6@   �� 5�      $��0��6   $
��Left=�6)   $	��Top=�6D   $��2��6\   $��20��6i   #��[ 6v   $��	317,8,0,0q�6�   $��Search��6�   #��[ 6�   y�5�      `� 5�      # [  6#   .1�5�      �� $ cmbQuotNoSearch��6"   $ Text.IsEmpty�6@   �� 5�      $ cmbQuotNoSearch��6"   $ 	IsFocused�6@   5�      5�      �� 5�      $ Vertical=�6   $��3��60   $��0��6=   $��3��6M   $��0,0,5,5q�6a   .+�5�      �  5�      �� 5�      $	��50* �6+   .+�5�      &   System.Windows.Controls.DataGrid  -   5          Name$ CustomGridLines��5�          GridLinesVisibility$	  All=�5�   P   !   HorizontalGridLinesBrush
! �����"   VerticalGridLinesBrush
" �����#   AutoGenerateColumns# .  $��15,0,0,0q�5�      $$   HorizontalScrollBarVisibility$$ Hidden=�5�      "%   VerticalScrollBarVisibility$% Disabled=�6C   $
��Left=�6j    	 BackHeaderStyle20&   ColumnHeaderStyle#& [	 5�      '   HeadersVisibility$	' All=�6R   ��5�   8   �� *BackGroundLines+��5�      �� $	 dg1��$ ActualHeight���6l   �� $	 dg1��$ ActualWidth�(   Columns( 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn)   Header$)  ��61   *   Width5	  /System.Windows.Controls.DataGridLengthConverter$	* 150	 6T   1
  +System.Windows.Controls.DataGridBoundColumn+ 
  Binding+ 6;   �� *Col0+6b     5�      $)  ��61   $	* 150	 6U   + 6;   �� *Col1+6c     5�      $)  ��61   $	* 150	 6U   + 6;   �� *Col2+6c   5�        5�      -   5        $	 dg1��5�   U    . $	  All=�6:   $��0��6b   ,   CanUserAddRows, .  -   CanUserDeleteRows- .  .   SelectionMode$. Single=�6�   $	��Top=�6�   $$ Hidden=�5�   9   $	��470��6b   # .  $��1q�5�      
������ $
��Left=�6M   $��15,0,0,0q�6h    
 HeaderStyle20#& [
 5�       $��2��6S   ��5�   r   �� *JournalListEntity+��5�      �� *SIGridHeight+( 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      -   5        
TxtJnumber��$	* 150	 5�   I   $) 
Journal No��6W   /   SortMemberPath$/ 
Journal No��6k   0   HeaderTemplate0 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   $
��auto �6C   �� 5�   2   $��10 �6D   .+�5�   .   �� $��
Journal No��68   $
��Left=�6J   6g   �� 5�   .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5�   1   $��20��6<   $
��Left=�5�   ,   $��1��5�   ,   5�   +   5�   '   1   CellTemplate1 5�   "   �� 5�   &   .R�5�   *   �� $
��Wrap=�64   �� 5�   .     HyperlinkDataGrid#��[ 69   2 �� Command2 6d   �� *#!DataContext.NavigatetoJournalForm+ �� " >�.�6�   .�5   .   �� .F�5  2   �� 3 �� TextAlignment$
3 Left=�6U   $
��Left=�6j   ��6<   �� *	JNumber+6j   5  /   4 �� CommandParameter4 5  .   `� 5  .   # [ 6;   .1�5  3   �� $ JNumber�6;   5  0   .�5  F   5	  +   5
  +   5  '   5       5     -   5        txtDate��$) Journal Date��5  F   $	* 150	 6\   5   MinWidth$	5 150Q�6h   6   MaxWidth$	6 150Q�6w   $
/ Date��6�     HeaderStyle20Right7   HeaderStyle#7 [ 6�   0 5  "   �� 5  &   .R�5  *   � $��Stretch=�6/    5  .   �� 5  2   $
��auto �6C   �� 5  2   $��10 �6D   .+�5  .   �� $��Journal Date��68   6N   �� 5  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5  1   $��20��6<   $
��Left=�5  ,   $��1��5  ,   5  +   5  '   1 5  "   �� 5  &   .R�5   *   �� $��Right=�64   �� 5!  -   $3 Right=�6T   ��67   �� *JournalDate+6l   5.  *   5/  '   51       54     -   5        
TxtAmount1��$	* 150	 54  I   $) Journal Amount��6W   $/ Amount��6o   #7 [ 6�   0 55  "   �� 56  &   .R�57  *   �  58  .   �� 59  2   $
��auto �6C   �� 5:  2   $��10 �6D   .+�5<  .   �� $��Journal Amount��68   $��Right=�6N   6l   �� 5=  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5>  1   $��20��6<   $��Right=�5?  ,   $��1��5@  ,   5A  +   5B  '   1 5I  "   �� 5J  &   .R�5K  *   �� $
��Wrap=�6P   $��Right=�6d   ��64   �� *
Amount1Str+6�   5L  '   5N     5P     5Q     �� 5S     $	��467��6   $ 
Horizontal=�6+   $
��left=�6D   $��17,1,0,1q�6_   $��14��6q   .+�5T     � ��6   �� $ 
TxtJnumber��$ ActualWidth�.+�5U     ��   BorderStyleLeft#��[ 6!   ._�5V     �� $
��Left=�6(     DisplayTotalStyle#��[ 6�   ��6D   �� *ShowSelectedCount+$ TwoWay=�$ PropertyChanged=�6�   5W     5X     � 5[     $
��Left=�6S   ��6   �� $ txtDate��$ ActualWidth�.+�5\     �� #��[ 6!   ._�5]     �� $
��Left=�6(   6E   5^     5_     � 5b     $��Right=�6U   ��6   �� $ 
TxtAmount1��$ ActualWidth�.+�5c     �� #��[ 6!   ._�5d     �� $��Right=�6(   #��[ 6�   ��6E   �� *TotalAmount+$ TwoWay=�$ PropertyChanged=�6�   5e     5f     5h     5i     �� 5j     $��10 0 0 0q�6   $��4��6+   $��0��68   $��3��6H   $ 
Horizontal=�6\   $��Bottom=�6u   .+�5o     �� $��  Amounts are in  ��6   $��Italic$�67   
�������6^   �� 5p     $��Italic$�6:   
���������6   �� *CurrencyName+6a   5r     �� 5s     $ 
Horizontal=�6   $��3��62   $��4��6B   $��Right=�6O   $��0,0,0,0q�6l   $��Bottom=�6}   .+�5t     �� $	��New��6   $	��4 0q�6(     ButtonStyle#���  65   $	��New��6�   ��6[   �� *NavigaetoJournalFormCommand+6�   �� 5u     $��Close��6   $
��17 0q�6*   #���  68   $	��New��6   ��6^   �� *CloseCommand+6   5v     5w     5x     5y     