   M S B A M L   `   `   `  ����I  ESDN.Navigation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SDN.Navigation.ViewSDN.Navigation.View  5      3    -SDN.Navigation.View.OpenCompanyFileDBNameView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:SDN.Navigation.View     5      $	��180��5      $	��380��6   
���   �$��1q�6;   .��5	      �   � RowDefinitions  5
   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      $	��110 �6   6-   �� 5      6!   .+�5   
   �� $��0��6   $��0��6!   $��Select Server Name��62   $��3,10,0,0q�6L   $��2��6^   $	��133��6r   6�   �� 5   
   $��0��6   $��10��6!   $��1��6-   $��	44,5,10,5q�6=    �� SelectedItem 6P   �� *SelectedServerItem+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���6�   �� *SelectServerName+$ PropertyChanged=�$ TwoWay=��� 5   
   $��1��6   $��0��6!   $��Select Database Name��62   $��3,10,0,0q�6N   $��2��6`   $	��133��6t   6�   �� 5   
   $��1��6   $��10��6!   $��2��6-   $��	44,5,10,5q�6=    6P   �� *SelectedDatabaseItem+$ TwoWay=�$ PropertyChanged=���6�   �� *SelectDatabaseName+$ PropertyChanged=�$ TwoWay=��� 5   
   $��60��6   $��Ok��6�   $
��Left=�6�   $��45 0 0 0q�6�   $��22��6�      AuditTrialButton#���   6�   $��2��6
  $��1��6  ��6   �� *SuccessCommand+��6?   �� *DatabaseName+$ OneWay=�$ PropertyChanged=�6)  �� 5   
   -   5        $��60��5      $
��Exit��6;   $��Right=�6J   $��	10 0 10 0q�6f   $��22��6y   #���   6�   $��2��6�   $��1��6�   6�   �� 5   
   $��3��6   $��2��6!   $��	25 20 0 0q�65   $.��(@2017 Simple Accounting Software Pte Ltd��6H   6z   5      5      