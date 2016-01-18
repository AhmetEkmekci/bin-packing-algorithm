using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class box : System.Web.UI.Page
{
/*
       r     g      b      y     p
       1     2      33     44    5
      11     22     3       4    5
                                 5
*/

    //dizi boyutu                                   boxes.Rank
    //dizi seçilen boyutun uzunluğu                 boxes.GetUpperBound(0)
    int[,,] boxes;
    int n, npow;
    int dx, dy;

    public box()
    {
       
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        n = Convert.ToInt32(Session["n"]);//Convert.ToInt32(n_txt.Text);
        dx = Convert.ToInt32(Session["dx"]);//Convert.ToInt32(n_txt.Text);
        dy = Convert.ToInt32(Session["dy"]);//Convert.ToInt32(n_txt.Text);
        npow = Convert.ToInt32(Math.Pow(2, n));
        boxes = new int[npow, npow,2];
        //if (!IsPostBack)
        {
            if (Session["create"].ToString() != "1")
            {
                Random rnd = new Random();
                for (int i = 0; i <= boxes.GetUpperBound(0); i++)
                {
                    for (int k = 0; k <= boxes.GetUpperBound(1); k++)
                    {
                        boxes[i, k, 0] = rnd.Next(1, 6);
                    }
                }
            }
            else
            {
               
                CreateBoxes(true, 0, 0, boxes.GetUpperBound(0), boxes.GetUpperBound(1),dx,dy);
            }

            fillBoxPanel();
        }

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        n_txt.Text = n.ToString();
    }

    protected void create_btn_Click(object sender, EventArgs e)
    {
        Session["n"] = n_txt.Text;
        Session["create"] = "0";
        Response.Redirect("box.aspx");
    }


    //               0        1      2        3       4         5
    string[] bg = { "white", "red", "green", "blue", "yellow", "purple" };
    Button bx;
    Literal li;
    void fillBoxPanel()
    {
        for (int i = 0; i <= boxes.GetUpperBound(0); i++)
        {
            for (int k = 0; k <= boxes.GetUpperBound(1); k++)
            {

                bx = new Button();
                bx.Style.Add(HtmlTextWriterStyle.BackgroundColor,   bg[boxes[i, k, 0]]);

                bx.CssClass = "btn b" + boxes[i, k, 1];
                bx.Text = "";// boxes[i, k, 0].ToString();
                bx.CommandName = i.ToString();
                bx.CommandArgument = k.ToString();
                bx.Command += new CommandEventHandler( bx_Command);

                Box_pnl.Controls.Add(bx);
            }

            li = new Literal();
            li.Text = "<br />";
            Box_pnl.Controls.Add(li);
        }
        li = new Literal();
        li.Text = "<br />";
        Box_pnl.Controls.Add(li);
    }

    void bx_Command(object sender, CommandEventArgs e)
    {


        Session["dx"] = e.CommandName;
        Session["dy"] = e.CommandArgument;
        Session["create"] = "1";
        Response.Redirect("box.aspx");


    }

    void CreateBoxes(bool r,int x1, int y1, int x2, int y2,int _x,int _y)
    {
        //if you want to see the creation steps, activate this function.
        //fillBoxPanel();

        int midx = ((x2 - x1 + 1) / 2) + x1;
        int midy = ((y2-y1+1) / 2)+y1;
        byte position;
        if ((_x) < midx)
        {
            if ((_y) < midy)
            {
                boxes[midx - 1, midy, 0] = 1;
                boxes[midx, midy - 1, 0] = 1;
                boxes[midx, midy, 0] = 1;

                boxes[midx - 1, midy, 1] = 1;
                boxes[midx, midy - 1, 1] = 2;
                boxes[midx, midy, 1] = 3;

                position = 0;
            }
            else
            {
                boxes[midx - 1, midy - 1, 0] = 2;
                boxes[midx, midy - 1, 0] = 2;
                boxes[midx, midy, 0] = 2;

                boxes[midx - 1, midy - 1, 1] = 4;
                boxes[midx, midy - 1, 1] = 5;
                boxes[midx, midy, 1] = 6;
             
                position = 1;
            }
        }
        else
        {
            if ((_y) < midy)
            {
                boxes[midx - 1, midy - 1, 0] = 3;
                boxes[midx - 1, midy, 0] = 3;
                boxes[midx, midy, 0] = 3;

                boxes[midx - 1, midy - 1, 1] = 7;
                boxes[midx - 1, midy, 1] = 8;
                boxes[midx, midy, 1] = 9;

                position = 2;
            }
            else
            {
                boxes[midx - 1, midy - 1, 0] = 4;
                boxes[midx - 1, midy, 0] = 4;
                boxes[midx, midy - 1, 0] = 4;

                boxes[midx - 1, midy - 1, 1] = 10;
                boxes[midx - 1, midy, 1] = 11;
                boxes[midx, midy - 1, 1] = 12;

                position = 3;
            }
        }

        if ((x2 - x1) > 1)
        {
            switch (position)
            {
                case 0:
                    {
                        CreateBoxes(true, x1, y1, midx-1, midy-1,_x,_y);
                       
                        CreateBoxes(true, x1, midy, midx - 1, y2, midx-1, midy);
                        CreateBoxes(true, midx, y1, x2, midy - 1, midx, midy-1);
                        CreateBoxes(true, midx, midy, x2, y2,midx,midy);
                        
                    }
                    break;
                case 1:
                    {
                        CreateBoxes(true, x1, midy, midx - 1, y2, _x, _y);
                        
                        CreateBoxes(true, x1, y1, midx - 1, midy - 1, midx-1,midy-1);
                        CreateBoxes(true, midx, y1, x2, midy - 1, midx,midy-1);
                        CreateBoxes(true, midx, midy, x2, y2, midx,midy);

                    }
                    break;
                case 2:
                    {
                        CreateBoxes(true, midx, y1, x2, midy - 1, _x, _y);
                        
                        CreateBoxes(true, x1, y1, midx - 1, midy - 1, midx - 1, midy - 1);
                        CreateBoxes(true, x1, midy, midx - 1, y2 , midx-1,midy);
                        CreateBoxes(true, midx, midy, x2, y2, midx, midy);

                    }
                    break;
                case 3:
                    {
                        CreateBoxes(true, midx, midy, x2, y2, _x, _y);
                       
                        CreateBoxes(true, x1, y1, midx - 1, midy - 1, midx - 1, midy - 1);
                        CreateBoxes(true, x1, midy, midx - 1, y2, midx - 1, midy);
                        CreateBoxes(true, midx, y1, x2, midy - 1, midx, midy - 1);

                    }
                    break;
            }
        }
    }

    
       

    

}
