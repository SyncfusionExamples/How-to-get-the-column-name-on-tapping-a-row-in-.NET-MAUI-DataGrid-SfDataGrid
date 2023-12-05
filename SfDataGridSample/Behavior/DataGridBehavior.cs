using Syncfusion.Maui.DataGrid;
using Syncfusion.Maui.DataGrid.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridSample.Behaviors
{
    public class DataGridBehavior : Behavior<SfDataGrid>
    {
        protected override void OnAttachedTo(SfDataGrid dataGrid)
        {
            dataGrid.CellTapped += SfDataGrid_CellTapped;
            base.OnAttachedTo(dataGrid);
        }

        protected override void OnDetachingFrom(SfDataGrid dataGrid)
        {
            dataGrid.CellTapped -= SfDataGrid_CellTapped;
            base.OnDetachingFrom(dataGrid);
        }

        private void SfDataGrid_CellTapped(object? sender, DataGridCellTappedEventArgs e)
        {
            SfDataGrid grid = (SfDataGrid)sender;     
            int columnIndex;
            string columnName;
            columnIndex = grid.ResolveToGridVisibleColumnIndex(e.RowColumnIndex.ColumnIndex);
            columnName = grid.Columns[columnIndex].MappingName;

            Page currentPage = GetParentPage((View)sender);
            currentPage.DisplayAlert("Setected Column Name", columnName, "Cancel");
        }
        private Page GetParentPage(View view)
        {
            Element parent = view.Parent;

            while (parent != null)
            {
                if (parent is Page page)
                {
                    return page;
                }

                parent = parent.Parent;
            }

            return null;
        }
    }
}
