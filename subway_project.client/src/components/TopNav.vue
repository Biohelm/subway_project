<script setup>
  import { useOrderStore } from "@/stores/useOrderStore";
  import { useSubStore } from "@/stores/SubStore";

  const orderStore = useOrderStore();
  const subStore = useSubStore();

  const resetCart = () => {
    if (orderStore.order.products.length > 0 || orderStore.order.subs.length > 0) {
      orderStore.resetOrder();
      subStore.resetSub(false);
    }
  };
</script>

<template>
  <div class="top-nav-container">
    <div>
      <RouterLink to="/" class="bottom-link">
        <img class="logo" src="../assets/imgs/SubWayNewLogo2.png" alt="Subway Logo" @click="resetCart">
      </RouterLink>
    </div>
    <div class="page-links">
      <RouterLink to="/kitchen" class="page-link" @click="resetCart">
        <p>Kitchen</p>
      </RouterLink>
      <RouterLink to="/customer" class="page-link" @click="resetCart">
        <p>Order List</p>
      </RouterLink>
    </div>
  </div>
</template>

<style>
  .logo {
    width: 20rem;
    cursor: pointer;
  }

  .page-links {
    grid-column: 5;
    display: grid;
  }

  .page-link {
    text-decoration: none;
    color: white;
    display: block;
    background-color: #297042;
    padding: 5px 10px;
    border: none;
    cursor: pointer;
    border-radius: 5px;
    font-size: 12px;
    margin-top: 10px;
    grid-column: 5;
    justify-content: end;
  }
</style>
