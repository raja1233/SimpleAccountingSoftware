   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SDN.Settings.ViewsSDN.Settings.Views  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      ;,clr-namespace:SDN.Common;assembly=SDN.Common
SDN.Common 5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	      *    $SDN.Settings.Views.UsersSecurityView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:SDN.Settings.Views     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      ;my,clr-namespace:SDN.Common;assembly=SDN.Common     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5	      $
��1024��5
        � 	Resources  5       	  items �� Source �� Path.  (SDN.Common.Converter.RowToIndexConverter  RowToIndexConverter4  .SDN.Common.Converter.BoolToVisibilityConverter  BoolToVisibility0  *SDN.Common.Converter.SelectedItemConvertor  SelectedItemToItemsSource��%�   &	        &	 $     &	 7     &	 J     �� 5   
    6-   �� $ .�  5   
   6&     5   
   6,     5   
   6(   5      .��5      �� $
��Auto=�6   $
��Auto=�66   .��5      � $��10 10 10 10q�6    � RowDefinitions 5   
   �� 5      $��20 �6   6*   �� 5      $��40 �6   6*   �� 5      $
��Auto �6   6,   �� 5      $��60 �6   6*    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� $��0��6   $��0��6!   $	��Top=�61   $��2��6I   $L��FAdd/edit User then select User and click on a Menu Name or Screen Name��6]   $��Italic$�6�   
�������6�   � 5       $��1��6   $��0��6     5!      �� 5"      6)   �� 5#      6)   �� 5$      $
��.50* �6'   66   .+�5&      ]� $��0��6   $��1��6)   $��	-30 0 0 5q�69   .+�5'      �� $��Delete��6   $��Bottom=�6/     ButtonStyle#��[ 6K   $
��Left=�6q   ��6�   �� *DeleteRowCommand+6�   �� 5(      $
��New ��6   $��Bottom=�6-   #��[ 6H   $��10,0,0,0q�6n   $
��Left=�6�   ��6�   �� *AddNewRowCommand+6�   �� 5)      $
��Save��6   $��Bottom=�6-   #��[ 6H   $��10,0,0,0q�6n   $
��Left=�6�   ��6�   �� *SaveCommand+6�   5*      �� 5+      -   5        $��cbxAll2��5+   �   $��0��6   $��2��6(   $��Bottom=�68   $��	-97 0 0 5q�6S   $��Center=�6f   ��6�   �� *DataContext.CheckIsActive+ �� RelativeSource �� *FindAncestor+ �� AncestorType" >���5,   B   �� $ 	IsChecked� �� *Self+5-      �� 5.      $��0 0 33 0q�6   $
��Auto=�6-   $��0��6P   $��2��6`   $��1q�6m   .��5/      � .+�50      &   System.Windows.Controls.DataGrid  -   5          Name$ CustomGridLines��50      $��0��6`      GridLinesVisibility$	 All=�51   V   	   HorizontalGridLinesBrush
	 �����
   VerticalGridLinesBrush

 �����   AutoGenerateColumns .  $   HorizontalScrollBarVisibility$ Hidden=�53      "   VerticalScrollBarVisibility$ Disabled=�6C     BackHeaderStyle20   ColumnHeaderStyle# [ 54         HeadersVisibility$	 All=�6R   $��0,0,0,0q�6j   ��50   8   �� *BackGroundLines+��51      ��  �� ElementName$ 	datagrid1��$ ActualHeight���6r   �� $ 	datagrid1��$ ActualWidth�   Columns 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$  ��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 205 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Col0+6b     57      $  ��61   $	 160 6U    6;   �� *Col1+6c     58      $  ��61   $ 80 6U    6;   �� *Col2+6b   5;        5<      -   5        $��	datagrid1��5<   �     HeaderStyle20# [ 6   $��4��6R      CanUserDeleteRows .  
���   �$��1q�6�   
������ $	��Top=�6�      CanUserAddRows .   .     CanUserSortColumns .    CanUserResizeColumns .     CanUserResizeRows .  $	 All=�5=   8   �� SelectedItem 6   �� *SelectedUser+��65   �� *UserGridHeight+��6�   �� *UserSecurityEntity+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� 5>      4	  .System.Windows.Controls.DataGridTemplateColumn	  5?      $ 	User Name��65   $	 205 6H   -   5        userName��   SortMemberPath$ UserName��5?   g      HeaderTemplate 5@   "   �� 5A   &   .R�5B   *   �  5C   .   �� 5D   2   6B    5F   .   �� 5G   2   ��6C   �� $ userName��$ ActualWidth�.+�5I   .   ]� $��0��68   $��0��6E   .+�5J   2   �� $��txtuserName��6<   �� 5K   "   $�	User Name��6&   69   5L   3   �� 5M   2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5N   1   $��20��6<   $
��Left=�5O   ,   5Q   /   5S   +   5T   '    	  CellTemplate 5V   "   �� 5W   &   .R�5X   *   �� -   5        $��0q�5X   2   $��22��6F     �� 	MaxLength$  30��6�   ��6R   �� *
UserName+$ TwoWay=�$ PropertyChanged=�.��6�   5Y   +   5Z   '   5\      	  5]      $	 160 65   !   CanUserSort! .   5^   "   �� 5_   &   .R�5`   *   �� $��Password��64   6H   5a   '    5c   "   �� 5d   &   .R�5e   *   �� -   5        $��0q�5e   2   $��22��6F   $  30��6�   ��6R   �� *
Password+$ TwoWay=�$ PropertyChanged=�.��6�   5f   +   5g   '   5i      4
  .System.Windows.Controls.DataGridCheckBoxColumn
  5j      $ 80 65   ! .  $ Inactive��6T    6f   �� *
Isinactive+5k      "   	CellStyle" 5m      �� 5n      # �� 
TargetType*  $System.Windows.Controls.DataGridCell"#  6$   $ �� Triggers$ 5o   "   P� 5p   &   % P� Property% �@ 
IsSelected& P� Value& . . �5r   *   �� ' �� Property' � ��( �� Value
( �   �5s   2   �� 5t   *   ' � ��
( �   �5u   5   �� 5v   *   ' � ��
( �����5w   2   5y   '   5{      )   RowStyle) 5}      �� 5~      )  #System.Windows.Controls.DataGridRow"#  6$   $ 5   "   P� 5�   &   % �@ 
IsSelected& . . �5�   *   �� ' � ��
( �   �5�   2   �� 5�   *   ' � ��
( �   �5�   5   �� 5�   *   ' � ��
( �����5�   2   5�   '   5�      5�      5�      5�      � 5�      $��1��6   $��1��6    $��40��60   $	��Top=�6<    5�      �� 5�      6%   �� 5�      6%   .+�5�      ]� $��0��6   $��0��6)   $��	-23 0 0 5q�69   .+�5�      �� $��Bottom=�6   $��15 0 0 0q�6:   $
��Left=�6L   ��6h   �� *DataContext.CheckAllRoles+ �� *FindAncestor+" >���5�   B   �� $ 	IsChecked� �� *Self+5�      ]� 5�      $��0��6   $��0��6%   $��0 0 0 5q�65   .+�5�      �� $��Bottom=�6   $��0 0 82 0q�66   $��Right=�6H   ��6e   �� *DataContext.CheckAllRolesTab+ �� *FindAncestor+" >���5�   B   �� $ 	IsChecked� �� *Self+5�      5�      �� 5�   
   $��	-23,0,0,0q�6   $
��Auto=�6*   $��Hidden=�6M   $��1��6u   $��2��6�   $��1q�6�   .��5�      � .+�5�        -   5        $ CustomGridLinesRole��5�      $��0��6d   $	 All=�5�   U   
	 �����

 ����� .  $ Hidden=�5�      $ Disabled=�6C   # [ 5�      $	 All=�6R   $��0,0,0,0q�6j   ��5�   <   �� *BackGroundLines+��5�      �� $ RoleGrid��$ ActualHeight���6q   �� $ RoleGrid��$ ActualWidth� 5�        5�      $  ��61   $ 30 6T    6;   �� *Col0+6a     5�      $  ��61   $	 135 6U    6;   �� *Col1+6c     5�      $  ��61   $ 30 6U    6;   �� *Col2+6b     5�      $  ��61   $	 300 6U    6;   �� *Col3+6c     5�      $  ��61   $ 5 6U    6;   �� *Col0+6a   5�        5�      -   5        $��RoleGrid��5�   [   $	 All=�6   $��0��67   $��4��6G    .  
���   �$��1q�6   .  $	��Top=�6G  *   CanUserReorderColumns* .   .  $	��512��5�   K    .   .   .  $	 All=�6  # [ 5�      
������ $ Hidden=�6`   ��5�   �   �� *UserGridHeight++ �� SelectedValue+ 6�   �� *SelectedUserRole+$ TwoWay=�$ PropertyChanged=���5�   �   �� *UserRoleModelCollection+$ TwoWay=�$ PropertyChanged=� 5�      
  5�      $ 30 67   ,   
IsReadOnly, . $  ��6T    6_   �� *CheckModule+- �� NotifyOnTargetUpdated- . $ PropertyChanged=�.   	CellStyle. 5�   "   �� 5�   &   "#  6,   .�5�   *   -	   5        $ 5�   *   P� 5�   .   % �@ 
IsSelected& . . �5�   2   �� ' � ��
( �   �5�   2   �� 5�   2   ' � ��
( �   �5�   5   �� 5�   2   ' � ��
( �����5�   2   5�   /   5�   '   /   ElementStyle/ 5�   "   �� 5�   &   "# ��6,   .�5�   *   �� ' � ��$( Center=�6P   �� 5�   *   ' � ��$( Center=�6N   $ 5�   *   P� 5�   .   % �@d�	IsChecked& 6K   Z� . �5�   2   �� ' � y�$( Hidden=�6O   �� 5�   2   ' � ��
( �   �6S   �� 5�   2   ' � ��
( �   �6O   �� 5�   2   ' � ��
( �����6O   5�   /   5�   '   5�        5�      $	 135 61   , . $ 	Menu Name��6O    6c   �� *
ModuleName+5�      
  5�      $ 30 65   $  ��6@    6J   �� *
CheckTab+5�        5�      $	 300 61   , . $ Screen Name��6O    6d   �� *	TabName+5�      " 5�      �� 5�      "#  6$   $ 5�   "   P� 5�   &   % �@ 
IsSelected& . . �5�   *   �� ' � ��
( �   �5�   2   �� 5�   *   ' � ��
( �   �5�   5   �� 5�   *   ' � ��
( �����5�   2   5�   '   5�      ) 5      �� 5     "#  6$   $ 5  "   P� 5  &   % �@ 
IsSelected& . . �5  *   �� ' � ��
( �   �5  2   �� 5  *   ' � ��
( �   �5  5   �� 5	  *   ' � ��
( �����5
  2   5  '   5     5     5     5     ]� 5  
   $��3��6   $��1��6!   $��0 35 0 0q�62   $��Right=�6D   .+�5     �� $��3��6   $��1��6"   $
��Save��63   #��[ 6C   $��	10,0,10,0q�6i   ��6}   �� *SaveRolesCommand+6�   �� 5     $��3��6   $��1��6&   $��Close��6W   #��[ 6h   $��10,0,0,0q�6�   ��66   �� *CloseCommand+6�   5     �� 5     $��3��6   $��Bottom=�6%   $��0��6A   $
��Left=�6Q   $��0 0 0 0q�6l   $%��Password: Minimum 6 characters.��6}   $��Italic$�6�   
�������6�   5     5     5     