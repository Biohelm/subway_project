import { defineStore } from "pinia";
import { useOrderStore } from "@/stores/useOrderStore";

export const useSubStore = defineStore("subStore", {
  state: () => ({
    sub: {
      products: [],
    }
  }),

  actions: {
    addProduct(product) {
      const orderStore = useOrderStore();
      // Check if there is already bread in the sub
      const hasBread = this.sub.products.find((p) => p.subCategoryId === 1);
      if (hasBread && product.subCategoryId === 1) {
        console.log("PINIA: cannot add more bread to sub");
        return;
      }

      orderStore.order.totalPrice += product.price;
      orderStore.order.totalCalories += product.calories;
      this.sub.products.push(product);
      console.log("PINIA: added product", product, "to sub:", this.sub.products);

    },

    removeProduct(product) {
      const orderStore = useOrderStore();
      const index = this.sub.products.findIndex((p) => p.id === product.id);
      if (index !== -1) {
        this.sub.products.splice(index, 1);
        orderStore.order.totalPrice -= product.price;
        orderStore.order.totalCalories -= product.calories;
        console.log("PINIA: removed product", product, "from sub:", this.sub.products);
      } else {
        console.log("PINIA: product not found in sub:", product);
      }
    },

    resetSub(isClearSub) {
      if (isClearSub) {
        const orderStore = useOrderStore();
        orderStore.order.totalPrice -= this.sub.products.reduce((total, product) => total + product.price, 0);
        orderStore.order.totalCalories -= this.sub.products.reduce((total, product) => total + product.calories, 0);
      }
      this.sub = {
        products: [],
      };
      console.log("PINIA: sub has been reset");
    }
  }

})
