using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TestWork.Models;

namespace TestWork.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultTestCotroller : ControllerBase
    {


        [Route("ModulSum")]
        [HttpPost]
        public int GetModulSum(int[] sourceArr)
        {
            int moduloSum = 0;

            var oddNumber = sourceArr.Where(number => number % 2 != 0).ToArray();

            for (int i = 0; i < oddNumber.Length; i += 2)
            {
                moduloSum += Math.Abs(oddNumber[i]);
            }

            return moduloSum;
        }

        [Route("CheckPalindrome")]
        [HttpGet]
        public bool CheckPalindrome(string sourceStr)
        {
            var revStr = new string(sourceStr.Reverse().ToArray());

            if (sourceStr == revStr)
            {
                return true;
            }
            else
                return false;

        }

        [Route("SumLinkedLists")]
        [HttpPost]
        public ActionResult<LinkedList<int>> SumLinkedLists([FromBody] LinkedListContainer linkedListContainer)
        {
            var firstList = linkedListContainer.FirstList;
            var secondList = linkedListContainer.SecondList;

            LinkedList list = new LinkedList();

            list.head1 = new LinkedList.Node(firstList.First.Value);

            list.head1.next = new LinkedList.Node(firstList.Last.Value);


            list.head2 = new LinkedList.Node(secondList.First.Value);

            list.head2.next = new LinkedList.Node(secondList.Last.Value);

            LinkedList.Node rs = list.addTwoLists(list.head1, list.head2);         

            return  Ok(rs);
        }

    }    
}