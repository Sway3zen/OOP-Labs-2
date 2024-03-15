<script lang="ts">
  import { onMount } from 'svelte';
  import { popupData } from '../states';

  let inputValue: string = '';

  const save = () => {
    if (inputValue == '') {
      alert('Enter new value');
      return;
    }
    window.changeProfileInfo($popupData.returnType, inputValue);
  }

  const exit = () => {
    popupData.set({ title: '', returnType: '' });
  }

  onMount(() => {
    if ($popupData.title != '') {
      const bodyElement = document.querySelector('body');
      if (bodyElement) {
        bodyElement.style.overflow = 'hidden';

        const ChangeInfoPopUp = document.getElementById('ChangeInfoPopUp');
        if (ChangeInfoPopUp) {
          ChangeInfoPopUp.style.height = bodyElement.style.height;
        }
      }
    }
  })
</script>


<section id="ChangeInfoPopUp">
  <div class="container">
    <div class="title">
      {$popupData.title}
    </div>

    <input type="text" name="" id="" placeholder="Enter new value..." bind:value={inputValue}>

    <div class="btn">
      <button on:click={() => exit()}>Exit</button>
      <button on:click={() => save()}>Save</button>
    </div>
  </div>
</section>

<style lang="scss">
  #ChangeInfoPopUp {
    position: fixed;
    width: 100%;
    height: 100%;

    backdrop-filter: blur(10px);

    .container {
      position: fixed;
      top: 50%;
      left: 50%;
      transform: translate(-50%, -50%);

      width: auto;
      height: auto;

      max-width: 400px;

      background: rgba(230, 230, 230, 0.9);
      border-radius: 15px;


      padding: 20px;

      display: flex;
      flex-direction: column;
      gap: 10px;

      .title {
        font-size: 24px;
        font-weight: 700;

        word-wrap: break-word;
      }

      input {
        border: none;
        outline: none;

        background: rgba(219, 219, 219, 0.9);
        font-size: 16px;

        color: #000;

        padding: 10px 15px;
        border-radius: 9px;
      }

      .btn {
        display: flex;
        flex-direction: row;
        justify-content: center;
        align-items: center;
        gap: 10px;

        button {
          border: 2px solid #8DD3BB;
          border-radius: 6px;

          padding: 5px 15px;

          outline: none;
          background: transparent;

          display: flex;
          flex-direction: row;
          align-items: center;
          justify-content: center;

          font-size: 18px;

          pointer-events: all;
        }
      }
    }
  }
</style>