using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameoOfLife
{
    class Generation
    {
       const int BOARD_WIDTH = 60;
       const int BOARD_HEIGHT = 40;
       const int CELL_SIZE = 20;
       Cell[,] board = new Cell[BOARD_WIDTH, BOARD_HEIGHT];
       public void Mark()
        {
            for (int x = 0; x < BOARD_WIDTH; x++)
            {
                for (int y = 0; y < BOARD_HEIGHT; y++)
                {
                    MarkCell(x, y);
                }
            }
        }
       public void Draw(Graphics g, bool showInMarkedState)
       {
           for (int x = 0; x < BOARD_WIDTH; x++)
            {
                for (int y = 0; y < BOARD_HEIGHT; y++)
                {
                    
                    if (showInMarkedState)
                    {
                        //If the showInMarkedState​  is true  :draw the icon that represents what is going to happen to that organism
                        switch (board[x,y].state)
                        {
                            case 0: g.DrawImage(Properties.Resources.life_empty, CELL_SIZE * x, y * CELL_SIZE);
                                
                                break;
                            case 1: g.DrawImage(Properties.Resources.life_happy, CELL_SIZE * x, y * CELL_SIZE);

                                break;
                            case 2: g.DrawImage(Properties.Resources.life_overcrowded, CELL_SIZE * x, y * CELL_SIZE);

                                break;
                            case 3: g.DrawImage(Properties.Resources.life_sad, CELL_SIZE * x, y * CELL_SIZE);

                                break;
                            case 4: g.DrawImage(Properties.Resources.life_birthing, CELL_SIZE * x, y * CELL_SIZE);

                                break;
                           
                        }
                    }
                    else
                    {
                        //If the showInMarkedState​  is false :draw the generic organism icon
                        if (board[x, y].hasOrganism)
                        {
                             g.DrawImage(Properties.Resources.life_unmarked, 20 * x, y * 20);
                        }
                        else
                        {
                            g.DrawImage(Properties.Resources.life_empty, 20 * x, y * 20);
                        }
                       
                    }
                }
            }
       }
       public bool IsExtinct()
       {

           for (int x = 0; x < BOARD_WIDTH; x++)
           {
               for (int y = 0; y < BOARD_HEIGHT; y++)
               {
                  if (board[x,y].hasOrganism)
                  {
                      return true;
                  }
               }
               
           }
           return false;
       }
       void MarkCell(int x, int y)
       {
          int MyCountOrganism = CountOrganism(x, y);
          if (board[x,y].hasOrganism)
          {
              if (MyCountOrganism == 0 || MyCountOrganism==1)
              {//DEATH_BY_LONELINESS
                  board[x, y].state = 3;
                 
              }
              else if (MyCountOrganism>3)
              { //DEATH_BY_OVERCROWDING
                  board[x, y].state = 2;
                  
              }
              else
              {//SURVIVES
                  board[x, y].state = 1;
                
              }
          }
          else
          {
              if (MyCountOrganism==3)
              {
                  board[x, y].state = 4;
              }
          }
       }
       int CountOrganism(int x, int y)
       {
           //condition
           int count = 0;
           if (y!=0)
           {
               if (board[x, y - 1].hasOrganism)
               {
                   count++;
               }
           }
           if (y < BOARD_HEIGHT-1)
           {
               if (board[x, y + 1].hasOrganism)
               {
                   count++;
               }
           }
           if (x != 0)
           {
               if (board[x - 1, y].hasOrganism)
               {
                   count++;
               }
               if (y != 0)
               {
                   if (board[x - 1, y - 1].hasOrganism)
                   {
                       count++;
                   }
               }
               if (y < BOARD_HEIGHT-1)
               {
                   if (board[x - 1, y + 1].hasOrganism)
                   {
                       count++;
                   }
               }
           }


           if (x < BOARD_WIDTH-1)
           {
               if (board[x + 1, y].hasOrganism)
               {
                   count++;
               }
               if (y != 0)
               {
                   if (board[x + 1, y - 1].hasOrganism)
                   {
                       count++;
                   }
               }
               if (y < BOARD_HEIGHT-1)
               {
                   if (board[x + 1, y + 1].hasOrganism)
                   {
                       count++;
                   }
               }
           }
          
           return count;
       }
       public Generation Update()
       {
           Generation nextGen = new Generation();

           for (int x = 0; x < BOARD_WIDTH; x++)
           {
               for (int y = 0; y < BOARD_HEIGHT; y++)
               {
                   nextGen.board[x, y] = new Cell(false);
                   if (board[x,y].state==1)
                   {
                       nextGen.board[x, y].state = 5;
                       nextGen.board[x, y].hasOrganism = true;
                   }
                   else if (board[x, y].state == 4)
                   {
                       nextGen.board[x, y].state = 5;
                       nextGen.board[x, y].hasOrganism = true;
                   }
                 
               }
           }
           return nextGen;
       }
       public void AddOrganism(int x, int y)
       {
           if (x < BOARD_WIDTH && y<BOARD_HEIGHT)
           {
               board[x, y].hasOrganism = true;
               board[x, y].state = 5;
           }
          
       }
       public bool Equals(Generation g)
       {
           for (int x = 0; x < BOARD_WIDTH; x++)
           {
               for (int y = 0; y < BOARD_HEIGHT; y++)
               {
                  if (g.board[x,y].hasOrganism!=board[x,y].hasOrganism)
                  {
                      return false;
                  
                  }
               }
           }
           return true;
       }


    }
}
