<script setup>
  import { useOrdersStore } from '@/stores/OrdersStore'
  import { defineProps, computed } from 'vue';

  const ordersStore = useOrdersStore()

  const props = defineProps({
    type: String // "received", "inProgress", or "completed"
  })

  const title = computed(() => {
    switch (props.type) {
      case 'received':
        return 'Orders Received'
      case 'inProgress':
        return 'Orders In Progress'
      case 'completed':
        return 'Orders Completed'
      case 'collected':
        return 'Orders Collected'
      default:
        return ''
    }
  })

  const filteredOrders = computed(() => {
    switch (props.type) {
      case 'received':
        return ordersStore.FilteredOrdersRecieved
      case 'inProgress':
        return ordersStore.FilteredOrdersInProgress
      case 'completed':
        return ordersStore.FilteredOrdersCompleted
      case 'collected':
        return ordersStore.FilteredOrdersCollected
      default:
        return []
    }
  })

  async function updateOrder(order) {
    if (order.orderInProgress == null && order.orderCompleted == null && order.orderCollected == null) {
      await ordersStore.progressOrder(order.id);
      console.log("Order moved to in progress");
      return;
    }

    if (order.orderCompleted == null && order.orderCollected == null) {
      await ordersStore.completeOrder(order.id);
      console.log("Order moved to completed");
      return;
    }

    if (order.orderCollected == null) {
      await ordersStore.collectOrder(order.id);
      console.log("Order moved to collected");
      return;
    }
  }

  const groupedList = (products) => {
    const map = {}
    for (const product of products) {
      if (!map[product.name]) {
        map[product.name] = { ...product, quantity: 1 }
      } else {
        map[product.name].quantity += 1
      }
    }
    return Object.values(map)
  }

  const groupedSubList = (subs) => {
    return subs.map(sub => {
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
  };


</script>

<template>
  <h2>{{ title }}</h2>

  <ul class="order-list" v-if="ordersStore.ShowOrders">
    <li v-for="order in filteredOrders" :key="order.id">
      <button class="order-div" @click="updateOrder(order)">
        <div class="order-heading">
          Order: {{ order.id }} - {{ order.takeAway ? 'Take Away' : 'Eat Here' }}
        </div>

        <!-- Subs -->
        <div v-if="order.subs && order.subs.length">
          <p><strong>Subs:</strong></p>
          <div v-for="(sub, index) in groupedSubList(order.subs)" :key="index">
            <p><strong>Sub {{ index + 1 }}</strong></p>
            <ul>
              <li v-for="product in sub.products" :key="product.id">
                {{ product.name }} x {{ product.quantity }}
              </li>
            </ul>
          </div>
        </div>

        <!-- Drinks -->
        <div v-if="groupedList(order.products.filter(p => p.subCategoryId >= 6 && p.subCategoryId <= 7)).length">
          <p><strong>Drinks:</strong></p>
          <ul>
            <li v-for="product in groupedList(order.products.filter(p => p.subCategoryId >= 6 && p.subCategoryId <= 7))" :key="product.id">
              {{ product.name }} x {{ product.quantity }}
            </li>
          </ul>
        </div>

        <!-- Snacks -->
        <div v-if="groupedList(order.products.filter(p => p.subCategoryId >= 8 && p.subCategoryId <= 9)).length">
          <p><strong>Snacks:</strong></p>
          <ul>
            <li v-for="product in groupedList(order.products.filter(p => p.subCategoryId >= 8 && p.subCategoryId <= 9))" :key="product.id">
              {{ product.name }} x {{ product.quantity }}
            </li>
          </ul>
        </div>

        <!-- Desserts -->
        <div v-if="groupedList(order.products.filter(p => p.subCategoryId >= 10 && p.subCategoryId <= 11)).length">
          <p><strong>Desserts:</strong></p>
          <ul>
            <li v-for="product in groupedList(order.products.filter(p => p.subCategoryId >= 10 && p.subCategoryId <= 11))" :key="product.id">
              {{ product.name }} x {{ product.quantity }}
            </li>
          </ul>
        </div>
      </button>
    </li>
  </ul>
</template>

<style>
  .order-heading {
    margin-bottom: 0.5rem;
    font-weight: bold;
  }
</style>
