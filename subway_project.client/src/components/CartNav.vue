<script setup>
  import { ref, reactive, watch, computed } from "vue";
  import { useRouter } from "vue-router";
  import { useOrderStore } from "@/stores/useOrderStore";
  import { useSubStore } from "@/stores/SubStore";

  const orderStore = useOrderStore();
  const subStore = useSubStore();

  const props = defineProps({
    cartLimits: Object
  });

  const router = useRouter();

  const groupedList = computed(() => {
    const map = {}
    for (const item of orderStore.order.products) {
      if (!map[item.name]) {
        map[item.name] = { ...item, quantity: 1 }
      } else {
        map[item.name].quantity += 1
      }
    }
    return Object.values(map)
  });

  const groupedCartSubList = computed(() => {
    return orderStore.order.subs.map(sub => {
      const map = {};

      for (const product of sub.products) {
        if (!map[product.name]) {
          map[product.name] = { ...product, quantity: 1 };
        } else {
          map[product.name].quantity += 1;
        }
      }

      return {
        ...sub,
        products: Object.values(map)
      };
    });
  });

  const groupedSubList = computed(() => {
    const map = {}
    for (const item of subStore.sub.products) {
      if (!map[item.name]) {
        map[item.name] = { ...item, quantity: 1 }
      } else {
        map[item.name].quantity += 1
      }
    }
    return Object.values(map)
  });

  const checkout = () => {
    fetch("api/Orders", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(orderStore.order),
    })
      .then((response) => {
        if (response.ok) {
          console.log("The Pinia-order was saved successfully to database");
          router.push("/orderConfirmation"); //using this redirect to the OrderConfirmation page will result in the default timeout of 30 seconds.
          //router.push({ name: 'OrderConfirmation', query: { timeout: 15 } }); //using this redirect to the OrderConfirmation page will result in a timeout of 15 seconds (or whatever you set the timeout value to).
        }
        else {
          console.log("Something went wrong when saving the PINIA-order to the database");
          console.log('Tried to save following order: ', orderStore.order);
        }

      });
  };

  const isAddToSubDisabled = (subCatId) => {
    if (!props.cartLimits || !subStore.sub.products) {
      return false; // No limits or products in subStore, so not disabled
    }

    const subHasBread = subStore.sub.products.findIndex(product => product.subCategoryId === 1) !== -1; //check if there is bread in the sub
    if (!subHasBread) { //if there is no bread in the sub
      if (subCatId >= 2 && subCatId <= 5) { //if subcategory is vegetables/sauces/cheese/proteins
        return true; //return true to disable the button
      }
    }

    //if there is bread in the sub check number of items of the subcategory in the sub, and return true/false depending on if the limit is reached
    const productCount = subStore.sub.products.filter(product => product.subCategoryId === subCatId).length;
    return productCount >= props.cartLimits[subCatId];
  };

  const isAddSubToCartDisabled = () => {
    const subHasBread = subStore.sub.products.findIndex(product => product.subCategoryId === 1) !== -1;
    if (!subHasBread) {
      return true;
    }

    return false;

  };

  const IsCheckoutDisabled = () => {
    if (orderStore.order.products.length > 0 || orderStore.order.subs.length > 0) {
      if (subStore.sub.products.length > 0) {
        return true;
      }
      return false;
    }
    else {
      return true;
    }
  };

  const startNewOrder = () => {
    orderStore.resetOrder();
    subStore.resetSub(false);
    router.push("/");
  };

  const addSubToCart = () => {
    orderStore.addSubToOrder(subStore.sub);
    subStore.resetSub(false);
  };

</script>

<template>

  <div class="cart">

    <div class="cart-header">
      <div class="allergy-msg">Contact the staff if you have any allergies.</div>
      <span v-if="orderStore.order.products.length > 0 || orderStore.order.subs.length > 0 || subStore.sub.products.length > 0">
        <div class="cart-footer">
          <button @click="checkout" :disabled="IsCheckoutDisabled()">Finalize order</button>
          <div v-if="IsCheckoutDisabled()">
            <p v-if="subStore.sub.products.length > 0">You cannot checkout while building your sub. Please add the sub to the cart, or clear the sub, to be able to checkout.</p>
            <p v-else>You need to add a sub or other product to your order to be able to checkout.</p>
          </div>
        </div>
        Total: {{ orderStore.order.totalPrice }} kr
        <br>
        Calories: {{ orderStore.order.totalCalories }} kcal
        <p v-if="orderStore.order.takeAway">Takeaway</p>
        <p v-else>Eat Here</p>
      </span>
      <span v-else>
        Welcome!
        <br><br>
        Choose between our delicious dishes!
      </span>
    </div>

    <div v-if="subStore.sub.products.length > 0" class="sub-container">
      <!-- from subStore -->
      <span>Sub</span>
      <div v-for="product in groupedSubList" :key="product.id" class="cart-item">
        <div>
          <p>{{ product.name }} — {{ product.quantity }} x {{ product.price }} kr</p>
        </div>
        <div>
          <button @click="subStore.removeProduct(product)">-</button>
          <button @click="subStore.addProduct(product)" :disabled="isAddToSubDisabled(product.subCategoryId)">+</button>
          <!-- Visual Studio says "'isAddToSubDisabled(product.subCategoryId)' is not a valid value of attribute 'disabled'",
          but the functionality works as intended (i.e. the button is disabled if a certain amount of a product is in "groupedList").-->
        </div>
      </div>
      <button class="btn" @click="addSubToCart" :disabled="isAddSubToCartDisabled()">Add sub to cart</button>
      <button class="cancel-button" @click="subStore.resetSub(true)">Clear sub</button>
      <div v-if="isAddSubToCartDisabled()">
        <p class="sub-container-error">You need to add bread to your sub to be able to add it to the cart.</p>
      </div>
    </div>

    <div>
      <!-- from orderStore -->
      <div v-for="product in groupedList" :key="product.id" class="cart-item">
        <div>
          <p>{{ product.name }} — {{ product.quantity }} x {{ product.price }} kr</p>
        </div>
        <div>
          <button @click="orderStore.removeProduct(product)">-</button>
          <button @click="orderStore.addProduct(product)">+</button>
        </div>
      </div>
    </div>
    <div>
      <div v-for="sub in groupedCartSubList" class="cart-item-sub">
        <!--  orderStore.order.subs -->
        <div class="cart-item-sub-heading">
          <div>
            <p>Sub:</p>
          </div>
          <div>
            <button @click="orderStore.removeSub(sub)">-</button>
          </div>
        </div>
        <ul>
          <li v-for="product in sub.products" :key="product.id">{{ product.name }} — {{ product.quantity }} x {{ product.price }} kr </li>
        </ul>
      </div>
    </div>
    <div v-if="orderStore.order.products.length !== 0 || orderStore.order.subs.length !== 0" class="cart-footer cancel-button">
      <button @click="startNewOrder">Cancel order</button>
    </div>

  </div>
</template>

<style scoped>
  .cart {
    width: 90%;
    max-width: 600px;
    padding: 10px;
    background-color: #f9f9f9;
    border-radius: 10px;
    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  }

  .sub-container {
    display: flex;
    justify-content: center;
    margin: 20px 5px 60px 5px;
    flex-direction: column;
  }

    .sub-container span {
      font-size: 1.5em;
      font-weight: bold;
    }

    .sub-container button {
      background-color: #38a169;
      color: white;
      padding: 12px 24px;
      border: none;
      border-radius: 8px;
      cursor: pointer;
      font-size: 1rem;
      transition: background-color 0.3s ease;
      margin: 0 10px;
    }

      .sub-container button:hover {
        background-color: #2f855a;
      }

      .sub-container button:disabled {
        background-color: #e2e8f0;
        color: #a0aec0;
        cursor: not-allowed;
      }

    .sub-container .cancel-button {
      background-color: #e53e3e;
      margin-top: 10px;
    }

      .sub-container .cancel-button:hover {
        background-color: #c53030;
      }

  .sub-container-error {
    font-size: 0.9rem;
    margin-top: 5px;
    text-align: center;
  }

  .cart-header {
    text-align: center;
    font-size: 1.5rem;
    font-weight: bold;
    margin: 10px;
    color: #333;
  }

    .cart-header p {
      font-size: 1.0rem;
      font-weight: normal;
    }

  .cart-footer {
    display: flex;
    justify-content: center;
    margin: 20px 5px;
    flex-direction: column;
  }

    .cart-footer button {
      background-color: #38a169;
      color: white;
      padding: 12px 24px;
      border: none;
      border-radius: 8px;
      cursor: pointer;
      font-size: 1rem;
      transition: background-color 0.3s ease;
    }

      .cart-footer button:hover {
        background-color: #2f855a;
      }

      .cart-footer button:disabled {
        background-color: #e2e8f0;
        color: #a0aec0;
        cursor: not-allowed;
      }

    .cart-footer p {
      font-size: 0.9rem;
      margin-top: 5px;
    }

  .cancel-button button {
    background-color: #e53e3e;
    color: white;
    padding: 12px 24px;
    border: none;
    border-radius: 8px;
    cursor: pointer;
    font-size: 1rem;
    transition: background-color 0.3s ease;
    margin-top: 40px;
  }

    .cancel-button button:hover {
      background-color: #c53030;
    }

  .cart-item {
    display: flex;
    justify-content: space-between;
    align-items: center;
    background-color: white;
    padding: 12px;
    margin-bottom: 10px;
    border-radius: 8px;
    box-shadow: 0 2px 6px rgba(0, 0, 0, 0.1);
    font-size: 1.1rem;
  }

    .cart-item span {
      color: #555;
    }

    .cart-item button {
      background-color: #e2e8f0;
      border: none;
      color: #333;
      padding: 6px 12px;
      margin: 0 2px;
      border-radius: 6px;
      cursor: pointer;
      transition: background-color 0.3s ease, color 0.3s ease;
    }

      .cart-item button:hover {
        background-color: #edf2f7;
        color: #2d3748;
      }

      .cart-item button:active {
        background-color: #cbd5e0;
      }

      .cart-item button:disabled {
        background-color: #e2e8f0;
        color: #a0aec0;
        cursor: not-allowed;
      }

    .cart-item div {
      display: flex;
      flex-wrap: nowrap;
    }

  .cart-item-sub {
    display: flex;
    flex-direction: column;
    background-color: white;
    padding: 12px;
    margin-bottom: 10px;
    border-radius: 8px;
    box-shadow: 0 2px 6px rgba(0, 0, 0, 0.1);
    font-size: 1rem;
  }

    .cart-item-sub button {
      background-color: #e2e8f0;
      border: none;
      color: #333;
      padding: 6px 12px;
      margin: 0 2px;
      border-radius: 6px;
      cursor: pointer;
      transition: background-color 0.3s ease, color 0.3s ease;
    }

    .cart-item-sub p {
      font-weight: 500;
      font-size: 1.1rem;
    }

    .cart-item-sub ul {
      list-style-type: none;
      list-style-position: inside;
    }

    .cart-item-sub li {
      margin-left: 20px;
    }

  .cart-item-sub-heading {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
  }

  .allergy-msg {
    font-size: 1.3rem;
    color: #e53e3e;
    font-weight: bold;
    margin-bottom: 25px;
  }
</style>
