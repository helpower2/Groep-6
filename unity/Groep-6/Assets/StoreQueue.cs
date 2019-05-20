using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreQueue : MonoBehaviour
{
    [SerializeField] private float custemerSpaceing;
    [SerializeField] private Transform startingPoint;

    private List<Customer> customers = new List<Customer>();
    /// <summary>
    /// will add a customer to the line
    /// </summary>
    /// <param name="customer"></param>
    /// <returns>the posision in the queue</returns>
    public Vector2 AddCustomerToLine(Customer customer)
    {
        
        Vector2 pos = startingPoint.position + (custemerSpaceing * customers.Count * new Vector3(1,0,0));
        customers.Add(customer);
        //Debug.Log(pos);
        return pos;
    }
    /// <summary>
    /// will remove the customer returnt
    /// </summary>
    /// <returns>the next customer in the line</returns>
    public Customer GetCustomer()
    {
        var temp = customers[0];
        customers.RemoveAt(0);
        UpdatePosisions();
        return temp;
    }

    public Customer PeekCustomer()
    {
        if (customers.Count != 0)
        {
            return customers[0];
        }
        return null;
    }
    
    private void UpdatePosisions()
    {
        for (int i = 0; i < customers.Count; i++)
        {
            customers[i].SetPosision(startingPoint.position + (custemerSpaceing * i * new Vector3(1,0,0)));
        }
    }
}
