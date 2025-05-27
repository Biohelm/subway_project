import { defineStore } from 'pinia'
import { v4 as uuidv4 } from 'uuid';

export const useOrderStore = defineStore('order', {
  state: () => ({
    order: {
      takeAway: false,
      totalPrice: 0,
      totalCalories: 0,
      products: [],
      subs: [],
      customerId: uuidv4(),
    }
  }),

  actions: {
    addProduct(product) {
      this.order.products.push(product);
      this.order.totalPrice += product.price;
      this.order.totalCalories += product.calories;
      console.log('PINIA: price added: ', product.price, 'new total: ', this.order.totalPrice)
      console.log('PINIA: added product', product, 'to order:', this.order.products)
      console.log('PINIA: calories added: ', product.calories, 'new total: ', this.order.totalCalories)
    },

    removeProduct(product) {
      const index = this.order.products.findIndex(p => p.id === product.id);
      if (index !== -1) {
        this.order.products.splice(index, 1);
        this.order.totalPrice -= product.price;
        this.order.totalCalories -= product.calories;
        console.log('PINIA: removed price: ', product.price, 'new total: ', this.order.totalPrice)
        console.log('PINIA: removed product', product, 'from order:', this.order.products)
        console.log('PINIA: removed calories: ', product.calories, 'new total: ', this.order.totalCalories)
      } else {
        console.log('PINIA: product not found in order:', product)
      }
    },

    changeTakeAway(boolean) {
      this.order.takeAway = boolean;
      console.log('PINIA: changed take away to:', boolean)
      console.log('Total price', this.order.totalPrice)
    },

    addToTotalPrice(price) {
      this.order.totalPrice += price;
      console.log('PINIA: price added: ', price, 'new total: ', this.order.totalPrice)
    },

    addToTotalCalories(calories) {
      this.order.totalCalories += calories;
      console.log('PINIA: calories added: ', calories, 'new total: ', this.order.totalcalories)
    },

    addSubToOrder(sub) {
      this.order.subs.push(sub);
      console.log('PINIA: added sub', sub, 'to order:', this.order.subs)
    },

    removeSub(sub) {
      const index = this.order.subs.findIndex(s => s.id === sub.id);
      if (index !== -1) {
        this.order.subs.splice(index, 1);
        this.order.totalPrice -= sub.products.reduce((total, product) => total + product.price * product.quantity, 0);
        console.log('PINIA: removed sub', sub, 'from order:', this.order.subs)
      } else {
        console.log('PINIA: sub not found in order:', sub)
      }
    },

    resetOrder() {
      this.order = {
        takeAway: false,
        totalPrice: 0,
        totalCalories: 0,
        products: [],
        subs: [],
        customerId: uuidv4(),
      }
      console.log('PINIA: order has been reset')
    }
  }
})
