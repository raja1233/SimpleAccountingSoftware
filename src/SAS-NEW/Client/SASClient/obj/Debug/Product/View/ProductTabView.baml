   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SDN.Product.ViewSDN.Product.View  5      %    SDN.Product.View.ProductTabView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:SDN.Product.View     5      $
��auto��5      $
��auto��6-   .��5
      � $
��Left=�6   $
��auto��6'     � RowDefinitions  5   
   �� 5      $��4* �6   6*    � ColumnDefinitions 5   
   �� 5      $��4* �6   �� 5      $��4* �6   �� 5      $��4* �6   �� 5      $��4* �6   �� 5      $��4* �6   �� 5      $��4* �6   �� 5      $��4* �6   .+�5   
   	� $��P&S Details��6>      TabMenuButtonStyle#���   6X   $��0��6�   $��10,0,0,0q�6�    d� 	IsChecked 6   �� *PSDetailsTabTrue+��5      �� *PandSDetailsClickCommand+5      	� 5   
   $��P&S History��6>   #���   6Y   $��1��6�   $��10,0,0,0q�6�    6   �� *PSHistoryTabTrue+��5      �� *PandSHistoryClickCommand+5      	� 5   
   $��Stock In/Out Card��6B   #���   6^   $��2��6�   $��10,0,0,0q�6�    6   �� *StockInOutCardTabTrue+��5      �� *StockInOutCardClickCommand+	� 5   
   $��Count & Adjust Stock��6G   #���   6j   $��3��6�   $��10,0,0,0q�6�    6   �� *CountandAdjustStockTabTrue+��5       �� * CountandAdjustListClickCommand+	� 5!   
   $��P&S Sold��6:   #���   6Q   $��4��6~   $��10,0,0,0q�6�    6   �� *PSSoldTabTrue+��5"      �� *PandSSoldClickCommand+	� 5#   
   $��P&S Purchased��6?   #���   6[   $��5��6�   $��10,0,0,0q�6�    6   �� *PSPurchasedTabTrue+��5$      �� *PandSPurchaseClickCommand+	� 5%   
   $��Top P&S��69   #���   6O   $��6��6}   $��10,0,0,0q�6�    6   �� *TopPSTabTrue+��5&      �� *TopPandSClickCommand+5'      5)      