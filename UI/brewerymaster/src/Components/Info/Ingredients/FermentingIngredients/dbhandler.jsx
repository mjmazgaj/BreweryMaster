export const dbhandler = () => {

    const ingredients = [
        {
          id: 1,
          type: "Grain",
          name: "Viking Pilsner malt",
          percentage: 62.5,
          extraction: 82,
          ebc: 4,
          quantity: 3,
          reserved: 3,
          orderQuantity: 3,
          total: 13,
        },
        {
          id: 2,
          type: "Grain",
          name: "Strzegom Monachijski typ II",
          percentage: 20.8,
          extraction: 79,
          ebc: 22,
          quantity: 3,
          reserved: 3,
          orderQuantity: 3,
          total: 13,
        },
        {
          id: 3,
          type: "Grain",
          name: "Strzegom Karmel 150",
          percentage: 10.4,
          extraction: 75,
          ebc: 150,
          quantity: 3,
          reserved: 3,
          orderQuantity: 3,
          total: 13,
        },
      ];
      
    const ingredientsReservation = [
        {
          id: 1,
          type: "Grain",
          name: "Viking Pilsner malt",
          percentage: 62.5,
          extraction: 82,
          ebc: 4,
          order: "order 1",
          user: "user 1",
          date: "2015-05-16",
          reserved: 3,
          describtion: "Viking Pilsner malt describtion"
        },
        {
          id: 2,
          type: "Grain",
          name: "Strzegom Monachijski typ II",
          percentage: 20.8,
          extraction: 79,
          ebc: 22,
          order: "order 1",
          user: "ujser 1",
          date: "2015-05-16",
          reserved: 3,
          describtion: "Strzegom Monachijski typ II describtion"
        }
      ];
      
      const ingredientsOrdered = [
          {
            id: 1,
            type: "Grain",
            name: "Viking Pilsner malt",
            percentage: 62.5,
            extraction: 82,
            ebc: 4,
            user: "user 1",
            orderedDate: "2015-05-16",
            expectedDate: "2015-05-16",
            orderQuantity: 3,
            describtion: "Viking Pilsner malt describtion"
          },
          {
            id: 2,
            type: "Grain",
            name: "Strzegom Monachijski typ II",
            percentage: 20.8,
            extraction: 79,
            ebc: 22,
            user: "ujser 1",
            orderedDate: "2015-05-16",
            expectedDate: "2015-05-16",
            orderQuantity: 3,
            describtion: "Strzegom Monachijski typ II describtion"
          }
        ];

    return {
      ingredients,
      ingredientsReservation,
      ingredientsOrdered,
    };
  };