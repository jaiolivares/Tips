function flex(elemento){
    let flex = document.getElementById('flex')
    flex.innerHTML = ``;
    if(elemento==='flex'){
        flex.innerHTML = `
        <h3 class="font-weight-light">flex</h3>
        <div class="my-3">
        <code>
            div-Padre { <br>
            &nbsp;&nbsp;&nbsp;display:flex; <br> 
            }
        </code>
        </div>

        <div class="d-flex border border-dark p-2 bg-secondary">
        <div class="border border-white p-2 text-white m-2">Item Flex 1</div>
        <div class="border border-white p-2 text-white m-2">Item Flex 2</div>
        <div class="border border-white p-2 text-white m-2">Item Flex 3</div>
        </div>
        `
    }
    if(elemento==='column'){
        flex.innerHTML = `
        <h3 class="font-weight-light">flex-column</h3>
        <div class="my-3">
          <code>
            div-Padre { <br>
              &nbsp;&nbsp;&nbsp;display:flex; <br> 
              &nbsp;&nbsp;&nbsp;flex-direction: column; <br>
            }
          </code>
        </div>

        <div class="d-flex flex-column border border-dark p-2 bg-secondary">
          <div class="border border-white p-2 text-white m-2">Item Flex 1</div>
          <div class="border border-white p-2 text-white m-2">Item Flex 2</div>
          <div class="border border-white p-2 text-white m-2">Item Flex 3</div>
        </div>
        `
    }
    if(elemento==='justify-content'){
        flex.innerHTML = `
        <h3 class="font-weight-light">justify content</h3>
          <div class="my-3">
            <code>
              div-Padre { <br>
                &nbsp;&nbsp;&nbsp;display:flex; <br>
                &nbsp;&nbsp;&nbsp;justify-content: center; <br> 
              }
            </code>
          </div>
          
          <div class="d-flex justify-content-center border border-dark p-2 bg-secondary">
            <div class="border border-white p-2 text-white m-2">Item Flex 1</div>
            <div class="border border-white p-2 text-white m-2">Item Flex 2</div>
            <div class="border border-white p-2 text-white m-2">Item Flex 3</div>
          </div>

          <div class="my-3">
            <code>
              div-Padre { <br>
                &nbsp;&nbsp;&nbsp;display:flex; <br>
                &nbsp;&nbsp;&nbsp;justify-content: space-between; <br> 
              }
            </code>
          </div>
          
          <div class="d-flex justify-content-between border border-dark p-2 bg-secondary">
            <div class="border border-white p-2 text-white m-2">Item Flex 1</div>
            <div class="border border-white p-2 text-white m-2">Item Flex 2</div>
            <div class="border border-white p-2 text-white m-2">Item Flex 3</div>
          </div>

          <div class="my-3">
            <code>
              div-Padre { <br>
                &nbsp;&nbsp;&nbsp;display:flex; <br>
                &nbsp;&nbsp;&nbsp;justify-content: space-around; <br> 
              }
            </code>
          </div>
          
          <div class="d-flex justify-content-around border border-dark p-2 bg-secondary">
            <div class="border border-white p-2 text-white m-2">Item Flex 1</div>
            <div class="border border-white p-2 text-white m-2">Item Flex 2</div>
            <div class="border border-white p-2 text-white m-2">Item Flex 3</div>
          </div>

          <div class="my-3">
            <code>
              div-Padre { <br>
                &nbsp;&nbsp;&nbsp;display:flex; <br>
                &nbsp;&nbsp;&nbsp;justify-content: flex-end; <br> 
              }
            </code>
          </div>
          
          <div class="d-flex justify-content-end border border-dark p-2 bg-secondary">
            <div class="border border-white p-2 text-white m-2">Item Flex 1</div>
            <div class="border border-white p-2 text-white m-2">Item Flex 2</div>
            <div class="border border-white p-2 text-white m-2">Item Flex 3</div>
          </div>
        `
    }
}