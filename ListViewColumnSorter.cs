using System.Collections;
using System.Windows.Forms;

public class ListViewColumnSorter : IComparer
{
    /// <summary>
    /// Colonne a trier
    /// </summary>
    private int ColumnToSort;

    /// <summary>
    /// Ordre de trie
    /// </summary>
    private SortOrder OrderOfSort;

    private CaseInsensitiveComparer ObjectCompare;

    public ListViewColumnSorter()
    {
        ColumnToSort = 0;
        OrderOfSort = SortOrder.None;
        ObjectCompare = new CaseInsensitiveComparer();
    }

    /// <summary>
    /// Compare les deux objets
    /// </summary>
    /// <param name="x">Premier objet</param>
    /// <param name="y">Deuxieme objet</param>
    /// <returns>0 si égal négatif si x inferieur à y positif sinon </returns>
    public int Compare(object x, object y)
    {
        int compareResult;
        ListViewItem listviewX, listviewY;

        listviewX = (ListViewItem)x;
        listviewY = (ListViewItem)y;

        compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

        if (OrderOfSort == SortOrder.Ascending)
        {
            return compareResult;
        }
        else if (OrderOfSort == SortOrder.Descending)
        {
            return (-compareResult);
        }
        else
        {
            return 0;
        }
    }

    /// <summary>
    /// Choisir la colonne de trie
    /// </summary>
    public int SortColumn
    {
        set
        {
            ColumnToSort = value;
        }
        get
        {
            return ColumnToSort;
        }
    }

    /// <summary>
    /// Changer l'ordre de trie
    /// </summary>
    public SortOrder Order
    {
        set
        {
            OrderOfSort = value;
        }
        get
        {
            return OrderOfSort;
        }
    }

}