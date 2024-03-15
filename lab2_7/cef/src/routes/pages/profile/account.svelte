<script lang="ts">
  import Icon from '@iconify/svelte';
  import { onMount } from 'svelte';
  import { name, email, popupData } from '../../states';

  const openPopUp = (title: string, returnType: string) => {
    const object = {
      title: title,
      returnType: returnType
    }

    popupData.set(object);
  }

  onMount(() => {
    window.changeProfileInfo = function(returnType: string, value: string) {
      if (returnType == 'name') {
        name.set(value);
      }
      else if (returnType == 'email') {
        email.set(value);
      }
      else if (returnType == 'password') {
        alert('Password changed');
      }
      else {
        return;
      }

      popupData.set({ title: '', returnType: '' });
    }
  })
</script>

<div class="account">
  <div class="item">
    <div class="left">
      <span>Name</span>
      <span>{$name}</span>
    </div>
    <div class="right">
      <button on:click={() => openPopUp('Change name', 'name')}><Icon icon="grommet-icons:notes" /> Change</button>
    </div>
  </div>
  <div class="item">
    <div class="left">
      <span>Email</span>
      <span>{$email}</span>
    </div>
    <div class="right">
      <button on:click={() => openPopUp('Change email', 'email')}><Icon icon="grommet-icons:notes" /> Change</button>
    </div>
  </div>
  <div class="item">
    <div class="left">
      <span>Password</span>
      <span>*********</span>
    </div>
    <div class="right">
      <button on:click={() => openPopUp('Change password', 'password')}><Icon icon="grommet-icons:notes" /> Change</button>
    </div>
  </div>
</div>

<style lang="scss">
  .account {
    background: #FFF;
    border-radius: 12px;

    padding: 15px;

    display: flex;
    flex-direction: column;
    gap: 10px;

    .item {
      display: flex;
      flex-direction: row;
      justify-content: space-between;
      align-items: center;

      width: 100%;

      .left {
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-content: start;

        span:nth-child(1) {
          font-size: 14px;
          font-weight: 500;
        }
        span:nth-child(2) {
          font-size: 20px;
          font-weight: 700;
        }
      }

      .right {
        button {
          display: flex;
          align-items: center;
          justify-content: center;
          gap: 5px;

          padding: 10px 15px;

          background: transparent;
          outline: none;
          border: 1px solid #8DD3BB;
          border-radius: 6px;

          color: #000;

          font-size: 14px;
        }
      }
    }
  }
</style>